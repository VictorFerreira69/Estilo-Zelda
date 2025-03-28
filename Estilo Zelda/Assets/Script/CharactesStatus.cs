using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharactesStatus : MonoBehaviour,IDamageable
{

    [SerializeField] float lifeMax;
    [SerializeField] float speed;
    float life;


    public float LifeMax { get => lifeMax; }
    public float Speed { get => speed; }

   
    void Awake()
    {
        life = lifeMax;


    }

   
    void Update()
    {

    }
    protected abstract void Teste();


    protected virtual void Teste2()
    {
        
    }

    public  virtual void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Destroy(gameObject);
        }

    }




}