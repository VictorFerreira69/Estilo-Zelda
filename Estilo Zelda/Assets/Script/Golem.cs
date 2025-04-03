using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : CharactesStatus
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject door; 
    [SerializeField] private Sprite openDoorSprite;

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
            Animator rockAnimator = rock.GetComponent<Animator>();
            if (rockAnimator != null)
            {
                yield return new WaitForSeconds(rockAnimator.GetCurrentAnimatorStateInfo(0).length /2); 
                DealDamage(rock);
            }
            yield return new WaitForSeconds(rockAnimator.GetCurrentAnimatorStateInfo(0).length / 2); 
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
        }
        
        return rock;
    }

    private void DealDamage(GameObject rock)
    {
        if (player == null || rock == null) return;
        
        float distanceToPlayer = Vector2.Distance(rock.transform.position, player.position);
        if (distanceToPlayer < 1f)
        {
            player.GetComponent<IDamageable>()?.TakeDamage(35);
        }
    }

    protected override IEnumerator Die()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(1f);
        OpenDoor(); 
        Destroy(gameObject);
    }

   private void OpenDoor()
{
    if (door != null)
    {
        door.GetComponent<Collider2D>().enabled = true; 
        SpriteRenderer spriteRenderer = door.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && openDoorSprite != null)
        {
            spriteRenderer.sprite = openDoorSprite;
        }

        PortaFinal doorScript = door.GetComponent<PortaFinal>();
        if (doorScript != null)
        {
            doorScript.Open(); 
        }
    }
}
}
