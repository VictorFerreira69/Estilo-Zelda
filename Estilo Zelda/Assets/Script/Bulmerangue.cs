using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulmerangue : MonoBehaviour,IItem
{
    public float speed = 10f;
    public float maxDistance = 5f;
    public Sprite icon;
    public GameObject prefab;

    private Vector3 startPosition;
    private Vector3 direction;
    private bool returning;
    private Transform playerTransform;

    void Start()
    {
        startPosition = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (returning)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, playerTransform.position) < 0.5f)
            {
                Inventario inventory = FindObjectOfType<Inventario>();
                if (inventory != null)
                {
                    inventory.AddItem(this);
                }
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position += direction * speed * Time.deltaTime;
            if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
            {
                returning = true;
            }
        }
    }

    public void Throw(Vector3 throwDirection)
    {
        direction = throwDirection;
    }

    public GameObject GetGameObject()
    {
        return prefab;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && returning)
        {
            Inventario inventory = FindObjectOfType<Inventario>();
            if (inventory != null)
            {
                inventory.AddItem(this);
            }
            Destroy(gameObject);
        }
    }
}