using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    public Transform player;   
    public float smoothing = 5f;  
    public Vector3 offset;  
    void Start()
    {
      
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }

      
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
      
        Vector3 CamPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, CamPos, smoothing * Time.deltaTime);
    }
}