using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rato : CharactesStatus
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private Transform[] patrolPoints;
    
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private int currentPatrolIndex = 0;
    private bool isAttacking = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Teste()
    {
        throw new System.NotImplementedException();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        else if (distanceToPlayer <= detectionRange)
        {
            MoveTowards(player.position, moveSpeed);
        }
        else
        {
            Patrol();
        }
    }

    private void MoveTowards(Vector3 target, float speed)
    {
        animator.SetBool("isMovi", true);
        Vector3 direction = (target - transform.position).normalized;
        spriteRenderer.flipX = direction.x < 0;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void Patrol()
    {
        animator.SetBool("isMovi", true);
        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];
        MoveTowards(targetPatrolPoint.position, patrolSpeed);

        if (Vector2.Distance(transform.position, targetPatrolPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            spriteRenderer.flipX = patrolPoints[currentPatrolIndex].position.x < transform.position.x;
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetTrigger("ataque");
        
        yield return new WaitForSeconds(0.5f);
        
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            player.GetComponent<IDamageable>()?.TakeDamage(10);
        }
        
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.blue;
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            Gizmos.DrawSphere(patrolPoints[i].position, 0.2f);
            if (i < patrolPoints.Length - 1)
            {
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i + 1].position);
            }
        }
    }
}

