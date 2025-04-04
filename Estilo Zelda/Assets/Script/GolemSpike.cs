using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSpike : MonoBehaviour
{
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private float spikeDamage = 35f;
    
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    public IEnumerator SummonSpikes()
    {
        if (player == null) yield break;

        GameObject rock = Instantiate(rockPrefab, player.position, Quaternion.identity);

        Animator rockAnimator = rock.GetComponent<Animator>();
        if (rockAnimator != null)
        {
            rockAnimator.SetTrigger("spawn");
            yield return new WaitForSeconds(rockAnimator.GetCurrentAnimatorStateInfo(0).length / 2);
            DealDamage(rock);
            yield return new WaitForSeconds(rockAnimator.GetCurrentAnimatorStateInfo(0).length / 2);
        }

        Destroy(rock);
    }

    private void DealDamage(GameObject rock)
    {
        if (player == null || rock == null) return;

        float distanceToPlayer = Vector2.Distance(rock.transform.position, player.position);
        if (distanceToPlayer < 1f)
        {
            player.GetComponent<IDamageable>()?.TakeDamage(spikeDamage);
        }
    }
}
