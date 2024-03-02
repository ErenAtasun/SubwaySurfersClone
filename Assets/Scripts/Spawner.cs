using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObstaclePrefab; 

    public float fieldWidth = 10f; 
    public float yMin = 1f; 
    public float yMax = 3f; 

    public int obstacleNum = 10; 
    public float spawnInterval = 1f; 


    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    
    }

    void SpawnObstacle()
    {
        Vector3 position = new Vector3(Random.Range(-fieldWidth / 2f, fieldWidth / 2f), Random.Range(yMin, yMax), transform.position.z);
        
        Quaternion rotation = Quaternion.Euler(0f, 180f, 0f); 
        GameObject newObstacle = Instantiate(ObstaclePrefab, position, rotation);
        Destroy(newObstacle, 10f);
    }

    
}
