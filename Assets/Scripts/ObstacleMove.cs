using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket hýzý
    public GameObject characterPrefab;

    void Update()
    {
       
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
    }
}
