using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObstaclePrefab; // Olu�turulacak engel prefab�

    public float fieldWidth = 10f; // Engellerin olu�turulaca�� alan�n geni�li�i
    public float yMin = 1f; // Engellerin en altta olabilece�i y�kseklik
    public float yMax = 3f; // Engellerin en �stte olabilece�i y�kseklik

    public int obstacleNum = 10; // Olu�turulacak engel say�s�
    public float spawnInterval = 1f; // Engeller aras�ndaki zaman aral���


    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    
    }

    void SpawnObstacle()
    {
        Vector3 position = new Vector3(Random.Range(-fieldWidth / 2f, fieldWidth / 2f), Random.Range(yMin, yMax), transform.position.z);
        GameObject newObstacle = Instantiate(ObstaclePrefab, position, Quaternion.identity);
        Quaternion spawnRotation = Quaternion.Euler(0f, 180f, 0f);
    }

    
}
