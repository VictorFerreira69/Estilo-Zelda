using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampada : MonoBehaviour,IItem
{
    [SerializeField] private Light lampLight; 
    [SerializeField] private Sprite lampIcon; 

    private void Start()
    {
        SetLight(false); 
    }

    public void SetLight(bool state)
    {
        if (lampLight != null)
        {
            lampLight.enabled = state;
        }
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Sprite GetIcon()
    {
        return lampIcon;
    }
}
