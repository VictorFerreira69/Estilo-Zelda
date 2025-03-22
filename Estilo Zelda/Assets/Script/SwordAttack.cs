using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private GameObject swordHitbox;
    private bool isAttacking = false;

  
    private void Start()
    {
        swordHitbox.SetActive(false);
    }

   
    public void OnComeçoAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            swordHitbox.SetActive(true); 
        }
    }

   
    public void OnFimDoAttack()
    {
        if (isAttacking)
        {
            isAttacking = false;
            swordHitbox.SetActive(false); 
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking && collision.CompareTag("Enemy"))
        {
          
            collision.GetComponent<IDamageable>()?.TakeDamage(10f);
        }
    }
}