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
    public float obstacleSpeed = 2f; // Engellerin h�z�

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        Vector3 position = new Vector3(Random.Range(-fieldWidth / 2f, fieldWidth / 2f), Random.Range(yMin, yMax), 0f);
        GameObject newObstacle = Instantiate(ObstaclePrefab, position, Quaternion.identity);

        // Engelleri belirli bir h�zla hareket ettir
        StartCoroutine(MoveObstacle(newObstacle.transform));
    }

    IEnumerator MoveObstacle(Transform obstacle)
    {
        while (true)
        {
            // Engelin pozisyonunu g�ncelle
            obstacle.position += Vector3.back * obstacleSpeed * Time.deltaTime;

            // Belirli bir zaman bekle
            ;
        }
    }
}