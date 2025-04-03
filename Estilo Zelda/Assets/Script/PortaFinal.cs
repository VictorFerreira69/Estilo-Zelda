using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortaFinal : MonoBehaviour
{
    private bool isOpen = false;

    public void Open()
    {
        isOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpen && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); 
        }
    }
}