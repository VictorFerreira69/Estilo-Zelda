using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajadoEscudo : MonoBehaviour,IItem
{
   
    [SerializeField] private Sprite cajadoIcon;

    private void Start()
    {
       
    }

  

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Sprite GetIcon()
    {
        return cajadoIcon;
    }
}
