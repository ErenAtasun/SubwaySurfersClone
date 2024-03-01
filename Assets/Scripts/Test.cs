using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float delay = 2f; // Objeyi yok etme gecikmesi (saniye cinsinden)

    private void OnTriggerEnter(Collider other)
    {
        // Karakter nesneye temas ettiðinde kontrol et
        if (other.gameObject.tag == "Player")
        {
            // Nesneyi 2 saniye sonra yok et
            Destroy(other.gameObject);
        }
    }
}

