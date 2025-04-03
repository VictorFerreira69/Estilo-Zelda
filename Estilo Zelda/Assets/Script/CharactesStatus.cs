using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharactesStatus : MonoBehaviour,IDamageable
{
    [SerializeField] float lifeMax;
    [SerializeField] float speed;
    [SerializeField] protected Animator animator;
    float life;

    public float LifeMax { get => lifeMax; }
    public float Speed { get => speed; }
    public float Life { get => life; set => life = value; }

   void Awake()
    {
        life = lifeMax;
       
    }


    protected abstract void Teste();

    protected virtual void Teste2()
    {
    
    }

    public virtual void TakeDamage(float damage)
    {
        life -= damage;
        animator.SetTrigger("Hit");
        if (life <= 0)
        {
            StartCoroutine(Die());
        }
    }

    protected virtual IEnumerator Die()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}