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
            IItem selectedItem = inventario.GetSelectedItem();
            if (selectedItem is Bulmerangue bulmerangueItem && bulmerangueItem.GetGameObject() != null)
            {
                GameObject bumerangue = Instantiate(bulmerangueItem.GetGameObject(), transform.position, Quaternion.identity);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                bumerangue.GetComponent<Bulmerangue>().Throw((mousePos - transform.position).normalized);
                inventario.RemoveItem(bulmerangueItem);
            }
            else
            {
                Debug.LogError("Bulmerangue Prefab e null ");
            }
        }
    }
}
