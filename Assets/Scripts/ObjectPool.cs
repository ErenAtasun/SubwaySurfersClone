using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] objects; // Havuzdaki objeleri tutmak için dizi
    private int currentIndex = 0; // Þu an hangi objenin kullanýldýðýný izlemek için bir indeks

    void Start()
    {
        // Baþlangýçta objeleri sýrayla yerleþtirme
        for (int i = 0; i < 3; i++)
        {
            Instantiate(objects[i], new Vector3(i * 10, 0, 0), Quaternion.identity).tag = "PooledObject";
        }
        currentIndex = 3;
        StartCoroutine(ObjectPooling());
    }

    IEnumerator ObjectPooling()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            // Havuzdaki bir önceki objeyi sil
            GameObject previousObject = GameObject.FindGameObjectWithTag("PooledObject");
            if (previousObject != null)
            {
                Destroy(previousObject);
            }

            // Yeni bir obje ekleyerek havuzu doldurma
            GameObject newObject = Instantiate(objects[currentIndex], new Vector3(Random.Range(-10f, 10f), 0, 0), Quaternion.identity);
            newObject.tag = "PooledObject";
            currentIndex = (currentIndex + 1) % objects.Length; // Bir sonraki objenin indeksini güncelleme
        }
    }
}
