using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private IInteractable interactable;
    private IItem nearbyItem;
    private Chest nearbyChest;
    private Inventario inventario;
    private PlayerStatus playerStatus;
    private PlayerHeath playerHeath;

    void Start()
    {
        inventario = FindObjectOfType<Inventario>();
        playerStatus = FindObjectOfType<PlayerStatus>();
        playerHeath = FindObjectOfType<PlayerHeath>();
    }

    void Update()
    {
      
        IItem selectedItem = inventario.GetSelectedItem();
        if (selectedItem != null && selectedItem is PocaoCura pocao && Input.GetKeyDown(KeyCode.F))
        {
            pocao.UsarPocao(playerStatus, playerHeath, inventario);
        }

        if (nearbyItem != null && Input.GetKeyDown(KeyCode.E))
        {
            inventario.AddItem(nearbyItem);
            Destroy(nearbyItem.GetGameObject());
            nearbyItem = null;
        }

        if (nearbyChest != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyChest.OpenChest();
            nearbyChest = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteractable target))
        {
            interactable = target;
        }

        if (collision.gameObject.TryGetComponent(out IItem item))
        {
            nearbyItem = item;
        }

        if (collision.gameObject.TryGetComponent(out Chest chest))
        {
            nearbyChest = chest;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;

        if (collision.gameObject.TryGetComponent(out IItem item))
        {
            if (item == nearbyItem)
            {
                nearbyItem = null;
            }
        }

        if (collision.gameObject.TryGetComponent(out Chest chest))
        {
            if (chest == nearbyChest)
            {
                nearbyChest = null;
            }
        }
    }

    public void BauAberto(Chest chest)
    {
        nearbyChest = chest;
    }

    public void BauFechado()
    {
        nearbyChest = null;
    }
}