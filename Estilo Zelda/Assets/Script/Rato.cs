using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rato : EnemyStatus
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator animator;
    private Transform player;
    private bool isAttacking = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance <= attackRange && !isAttacking)
            {
                StartCoroutine(Attack());
            }
            else if (distance <= detectionRange && distance > attackRange)
            {
                MovePlayer();
            }
            else
            {
                animator.SetBool("isMovi", false);
            }
        }
    }

    private void MovePlayer()
    {
        animator.SetBool("isMovi", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetTrigger("ataque");
        yield return new WaitForSeconds(0.5f);
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            player.GetComponent<IDamageable>()?.TakeDamage(damage);
        }
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        animator.SetTrigger("Hitt");


        if (Life <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        animator.SetTrigger("morte");
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }



}