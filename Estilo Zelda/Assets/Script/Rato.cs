using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rato : CharactesStatus
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    private Transform player;
    private bool isAttacking = false;
    private SpriteRenderer spriteRenderer;

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

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        else if (distance <= detectionRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            animator.SetBool("isMovi", false);
        }
    }

    private void MoveTowardsPlayer()
    {
        animator.SetBool("isMovi", true);

        Vector3 direction = (player.position - transform.position).normalized;
        spriteRenderer.flipX = direction.x < 0;

        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
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
    }
}