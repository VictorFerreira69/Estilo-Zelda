using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaj : MonoBehaviour
{ 
    private Inventario inventario;
    private CajadoEscudo cajadoEscudo;

    void Start()
{
    StartCoroutine(Initialize());
}

IEnumerator Initialize()
{
    yield return new WaitForSeconds(0.1f); 

    inventario = FindObjectOfType<Inventario>();
    cajadoEscudo = FindObjectOfType<CajadoEscudo>();

    if (inventario != null && cajadoEscudo != null && !inventario.ContainsItem(cajadoEscudo))
    {
        inventario.AddItem(cajadoEscudo);
    }
}

void Update()
{
    if (inventario != null && cajadoEscudo != null)
    {
        IItem selectedItem = inventario.GetSelectedItem();
        
        if (selectedItem == cajadoEscudo && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(cajadoEscudo.AtivarEscudo(transform));
        }
    }
}
}