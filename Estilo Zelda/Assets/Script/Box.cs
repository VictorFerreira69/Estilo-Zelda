using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool isHeld = false;
    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isHeld) return;
        
        transform.position = player.position + Vector3.up * 0.5f;

        if (Input.GetButtonUp("Fire2"))
        {
            Soltar();
        }
    }

    public void PickUp(Transform playerTransform)
    {
        if (isHeld) return;
        
        isHeld = true;
        player = playerTransform;
        rb.isKinematic = true;
    }

    private void Soltar()
    {
        isHeld = false;
        rb.isKinematic = false;
    }
}

