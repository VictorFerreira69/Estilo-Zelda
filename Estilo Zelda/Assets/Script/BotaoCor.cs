using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoCor : MonoBehaviour
{
    [SerializeField] private string requiredBoxTag;
    [SerializeField] private Sprite botaoAtivadoSprite;
    private SpriteRenderer spriteRenderer;
    private bool isActivated = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(requiredBoxTag)) return;
        
        isActivated = true;
        AtualizarSprite(botaoAtivadoSprite);
        NotificarPorta();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(requiredBoxTag)) return;
        
        isActivated = false;
        AtualizarSprite(null);
        NotificarPorta();
    }

    public bool IsActivated() => isActivated;

    private void AtualizarSprite(Sprite novoSprite)
    {
        if (spriteRenderer != null)
            spriteRenderer.sprite = novoSprite;
    }

    private void NotificarPorta()
    {
        Porta porta = FindObjectOfType<Porta>();
        porta?.ChecarBotoes();
    }
}