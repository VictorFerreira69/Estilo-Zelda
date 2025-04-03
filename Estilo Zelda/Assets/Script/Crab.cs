using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : CharactesStatus
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private Transform[] patrolPoints;
    
   Transform player;
     SpriteRenderer spriteRenderer;
   int currentPatrolIndex = 0;
    bool isAttacking = false;

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
        animator.SetBool("isMoving", true);
        Vector3 direction = (target - transform.position).normalized;
        spriteRenderer.flipX = direction.x > 0;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void Patrol()
    {
        animator.SetBool("isMoving", true);
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
        animator.SetTrigger("attack");
        
        yield return new WaitForSeconds(0.5f);
        
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            player.GetComponent<IDamageable>()?.TakeDamage(13);
        }
        
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}

   
