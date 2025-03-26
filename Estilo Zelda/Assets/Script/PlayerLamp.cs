using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLamp : MonoBehaviour
{
    private Inventario inventario;
    private Lampada lampada;

    void Start()
    {
        inventario = FindObjectOfType<Inventario>();
        lampada = FindObjectOfType<Lampada>();

        if (inventario != null && lampada != null)
        {
            inventario.AddItem(lampada); 
        }
    }

    void Update()
    {
        if (inventario != null && lampada != null)
        {
            IItem selectedItem = inventario.GetSelectedItem();
            lampada.SetLight(selectedItem == lampada);
        }
    }
}
