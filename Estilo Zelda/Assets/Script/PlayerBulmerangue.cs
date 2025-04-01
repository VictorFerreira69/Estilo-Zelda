using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulmerangue : MonoBehaviour
{
    private Inventario inventario;

    void Start()
    {
        inventario = FindObjectOfType<Inventario>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            TryThrowBoomerang();
        }
    }

    private void TryThrowBoomerang()
    {
        if (inventario.GetSelectedItem() is Bulmerangue bulmerangueItem && bulmerangueItem.GetGameObject() != null)
        {
            ThrowBoomerang(bulmerangueItem);
        }
    }

    private void ThrowBoomerang(Bulmerangue bulmerangueItem)
    {
        GameObject bumerangue = Instantiate(bulmerangueItem.GetGameObject(), transform.position, Quaternion.identity);
        bumerangue.SetActive(true);
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        
        bumerangue.GetComponent<Bulmerangue>().Throw((mousePos - transform.position).normalized);
        inventario.RemoveItem(bulmerangueItem);
    }
}

