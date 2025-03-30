using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocaoCura : MonoBehaviour,IItem
{
    [SerializeField] private float curaQuantidade = 20f;
    [SerializeField] private int usosTotais = 4;
    [SerializeField] private Sprite poçaoIcon;
    [SerializeField] private Sprite[] spritesPoçao;
    
    private int usosRestantes;

    void Start() => usosRestantes = usosTotais;

    public GameObject GetGameObject() => gameObject;

    public Sprite GetIcon() => poçaoIcon;

    public void UsarPocao(PlayerStatus playerStatus, PlayerHeath playerHealth, Inventario inventario)
    {
        if (usosRestantes > 0 && playerStatus.Life < playerStatus.LifeMax)
        {
            playerStatus.Life = Mathf.Min(playerStatus.Life + curaQuantidade, playerStatus.LifeMax);
            playerHealth.HealthUI();
            usosRestantes--;

            inventario.AtualizarIconePocao(usosRestantes, poçaoIcon, spritesPoçao);

            if (usosRestantes <= 0)
            {
                inventario.AtualizarIconeCadeado(this);
                inventario.RemoveItem(this);
                Destroy(gameObject);
            }
        }
    }
}