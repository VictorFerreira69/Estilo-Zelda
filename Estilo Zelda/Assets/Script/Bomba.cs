using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour,IItem
{
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private GameObject explosionEffect;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Sprite GetIcon()
    {
        return itemSprite;
    }

    public void Use()
    {
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(3f);
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}