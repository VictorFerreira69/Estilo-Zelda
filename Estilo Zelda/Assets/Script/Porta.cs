using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    [SerializeField] private BotaoCor botao1;
    [SerializeField] private BotaoCor botao2;
    [SerializeField] private GameObject porta;
    [SerializeField] private Sprite portaAbertaSprite;
    
    private BoxCollider2D portaCollider;
    private SpriteRenderer portaRenderer;

    private void Start()
    {
        portaCollider = porta.GetComponent<BoxCollider2D>();
        portaRenderer = porta.GetComponent<SpriteRenderer>();
    }

    public void ChecarBotoes()
    {
        if (botao1.IsActivated() && botao2.IsActivated())
        {
            AbrirPorta();
        }
    }

    private void AbrirPorta()
    {
        if (portaCollider != null) portaCollider.enabled = false;
        if (portaRenderer != null) portaRenderer.sprite = portaAbertaSprite;
    }
}
