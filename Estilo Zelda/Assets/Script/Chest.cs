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

       
        inventory.AddItem(itemScript);
      
       
       if (itemInChest.TryGetComponent<Bulmerangue>(out Bulmerangue bulmerangue))
       {
         bulmerangue.gameObject.SetActive(false); 
      }
       else
      {
      Destroy(itemInChest); 
      }
      itemInChest = null;
         
    }

    
    spriteRenderer.sprite = openChestSprite;
        Destroy(gameObject);
}
}



