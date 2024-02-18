using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] objects; // Havuzdaki objeleri tutmak i�in dizi
    private int currentIndex = 0; // �u an hangi objenin kullan�ld���n� izlemek i�in bir indeks

    void Start()
    {
        // Ba�lang��ta objeleri s�rayla yerle�tirme
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

            // Havuzdaki bir �nceki objeyi sil
            GameObject previousObject = GameObject.FindGameObjectWithTag("PooledObject");
            if (previousObject != null)
            {
                Destroy(previousObject);
            }

            // Yeni bir obje ekleyerek havuzu doldurma
            GameObject newObject = Instantiate(objects[currentIndex], new Vector3(Random.Range(-10f, 10f), 0, 0), Quaternion.identity);
            newObject.tag = "PooledObject";
            currentIndex = (currentIndex + 1) % objects.Length; // Bir sonraki objenin indeksini g�ncelleme
        }
    }
}
