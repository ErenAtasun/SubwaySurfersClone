using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObstaclePrefab; // Oluþturulacak engel prefabý
    public float fieldWidth = 10f; // Engellerin oluþturulacaðý alanýn geniþliði
    public float yMin = 1f; // Engellerin en altta olabileceði yükseklik
    public float yMax = 3f; // Engellerin en üstte olabileceði yükseklik

    public int obstacleNum = 10; // Oluþturulacak engel sayýsý
    public float spawnInterval = 1f; // Engeller arasýndaki zaman aralýðý
    public float obstacleSpeed = 2f; // Engellerin hýzý

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        Vector3 position = new Vector3(Random.Range(-fieldWidth / 2f, fieldWidth / 2f), Random.Range(yMin, yMax), 0f);
        GameObject newObstacle = Instantiate(ObstaclePrefab, position, Quaternion.identity);

        // Engelleri belirli bir hýzla hareket ettir
        StartCoroutine(MoveObstacle(newObstacle.transform));
    }

    IEnumerator MoveObstacle(Transform obstacle)
    {
        while (true)
        {
            // Engelin pozisyonunu güncelle
            obstacle.position += Vector3.back * obstacleSpeed * Time.deltaTime;

            // Belirli bir zaman bekle
            ;
        }
    }
}