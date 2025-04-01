using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulmerangue : MonoBehaviour,IItem
{
    public float speed = 10f;
    public float maxDistance = 5f;
    public Sprite icon;
    public GameObject prefab;
    public int damage = 10;

    private Vector3 startPosition;
    private Vector3 direction;
    private bool returning;
    private Transform playerTransform;
    private Inventario inventory;

    void Start()
    {
        startPosition = transform.position;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        inventory = FindObjectOfType<Inventario>();
    }

    void Update()
    {
        if (returning)
        {
            RetornaPLayer();
        }
        else
        {
            MoveForward();
        }
    }

    private void MoveForward()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
        {
            returning = true;
        }
    }

    private void RetornaPLayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, playerTransform.position) < 0.5f)
        {
            ColetarBulmerangue();
        }
    }

    private void ColetarBulmerangue()
    {
        if (inventory != null)
        {
            gameObject.SetActive(false);
            inventory.AddItem(this);
        }
    }

    public void Throw(Vector3 throwDirection)
    {
        direction = throwDirection;
        returning = false;
    }

    public GameObject GetGameObject() => prefab;
    public Sprite GetIcon() => icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && returning)
        {
            ColetarBulmerangue();
        }
        else if (collision.CompareTag("Enemy") && !returning)
        {
            collision.GetComponent<CharactesStatus>()?.TakeDamage(damage);
        }
    }
}
