using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private IInteractable interactable;
    private IItem nearbyItem;
    private Inventario inventario;

    void Start()
    {
        inventario = FindObjectOfType<Inventario>();
    }

    void Update()
    {
      
        if (Input.GetButtonDown("Fire1"))
        {
            interactable?.Interact();
        }

       
        if (nearbyItem != null && Input.GetKeyDown(KeyCode.E))
        {
            inventario.AddItem(nearbyItem);
            Destroy(nearbyItem.GetGameObject());
            nearbyItem = null;
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
    }
}

