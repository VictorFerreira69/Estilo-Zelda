using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : CharactesStatus
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject rockPrefab;
    
    private Transform player;
    private bool isAttacking = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    protected override void Teste()
    {
        throw new System.NotImplementedException();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetTrigger("ataque");
        yield return new WaitForSeconds(0.5f); 
        
        GameObject rock = SummonRock();
        
        if (rock != null)
        {
            yield return new WaitForSeconds(1f); 
            DealDamage(rock);
            Destroy(rock); 
        }
        
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    private GameObject SummonRock()
    {
        if (player == null) return null;
        
        GameObject rock = Instantiate(rockPrefab, player.position, Quaternion.identity);
        
        Animator rockAnimator = rock.GetComponent<Animator>();
        if (rockAnimator != null)
        {
            rockAnimator.SetTrigger("spawn");
            StartCoroutine(DestroyAfterAnimation(rock, rockAnimator));
        }
        
        return rock;
    }

    private IEnumerator DestroyAfterAnimation(GameObject rock, Animator animator)
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(rock);
    }

    private void DealDamage(GameObject rock)
    {
        if (player == null || rock == null) return;
        
        float distanceToPlayer = Vector2.Distance(rock.transform.position, player.position);
        if (distanceToPlayer < 1f)
        {
            player.GetComponent<IDamageable>()?.TakeDamage(25);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}