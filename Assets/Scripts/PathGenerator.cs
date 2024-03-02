using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject[] ground;
    
    public Transform player; 
    public float segmentLength = 10f; 
    public float generationDistance = 30f; 

    private float spawnZ = 0f; 

    void Start()
    {
       
        for (int i = 0; i < 5; i++)
        {
            SpawnPathSegment();
        }
    }

    void Update()
    {
        
        if (player.position.z > spawnZ - generationDistance)
        {
            SpawnPathSegment();
        }
    }

    void SpawnPathSegment()
    {
        int randomIndex = Random.Range(0, ground.Length);

        GameObject gameObject = Instantiate(ground[randomIndex], new Vector3(0, 0, spawnZ), Quaternion.identity);

        spawnZ += segmentLength;
    }
}
