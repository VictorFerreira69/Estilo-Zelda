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
    public float Life { get => life; set => life = value; }

    void Awake()
    {
        life = lifeMax; // A vida começa cheia
    }

    protected abstract void Teste();
    
    protected virtual void Teste2()
    {
        // Implementação do Teste2
    }

    public virtual void TakeDamage(float damage)
    {
        life -= damage; // Diminui a vida quando o jogador recebe dano
        if (life <= 0)
        {
            Destroy(gameObject); // Destroi o objeto (o jogador morre)
        }
    }
}