using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : CharactesStatus
{
    private bool invulneravel = false;

    protected override void Teste()
    {
        
    }

    protected override void Teste2()
    {
        // base.Teste2() 
    }

    public void SetInvulneravel(bool estado)
    {
        invulneravel = estado;
    }

    public override void TakeDamage(float damage)
    {
        if (invulneravel) return;

        base.TakeDamage(damage);

        PlayerHeath playerHealth = FindObjectOfType<PlayerHeath>(); 
        if (playerHealth != null)
        {
            playerHealth.HealthUI(); 
        }
    }
}