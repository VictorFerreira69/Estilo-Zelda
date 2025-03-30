using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite openChestSprite;
    public Sprite closedChestSprite;
    public GameObject itemInChest;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedChestSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInteraction playerInteraction = collision.GetComponent<PlayerInteraction>();
            playerInteraction.BauAberto(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInteraction playerInteraction = collision.GetComponent<PlayerInteraction>();
            playerInteraction.BauFechado();
        }
    }

   public void OpenChest()
{
    if (itemInChest != null)
    {
        Inventario inventory = FindObjectOfType<Inventario>();
        IItem itemScript = itemInChest.GetComponent<IItem>();

        // Adiciona o item ao inventário
        inventory.AddItem(itemScript);

        // Desativa o item no baú após pegar
        itemInChest.SetActive(false);
        itemInChest = null;
    }

    // Atualiza o sprite do baú
    spriteRenderer.sprite = openChestSprite;
}
}



