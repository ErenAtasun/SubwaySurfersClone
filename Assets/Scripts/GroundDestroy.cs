using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroy : MonoBehaviour
{
    public float delay = 2f;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            Destroy(this.transform.parent.gameObject, delay);
        }
    }
}
