using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSegurando : MonoBehaviour
{
    private Box nearbyBox;

    void Update()
    {
        if (nearbyBox != null && Input.GetButtonDown("Fire2"))
        {
            nearbyBox.PickUp(transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Box box))
        {
            nearbyBox = box;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Box box) && box == nearbyBox)
        {
            nearbyBox = null;
        }
    }
}

