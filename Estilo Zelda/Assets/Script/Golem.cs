using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : CharactesStatus
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject door;
    [SerializeField] private Sprite openDoorSprite;
    [SerializeField] private GolemSpike spikeSystem;

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

        if (spikeSystem != null)
        {
            yield return StartCoroutine(spikeSystem.SummonSpikes());
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
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