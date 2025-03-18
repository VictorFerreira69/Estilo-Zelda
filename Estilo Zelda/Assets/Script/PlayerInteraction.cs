using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    IInteractable interactable;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            interactable?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out IInteractable target))
        {
            interactable = target;
        }
        if (collision.gameObject.TryGetComponent(out ICollectable collectable))
        {
            Destroy(collision.gameObject);
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
    }
}

