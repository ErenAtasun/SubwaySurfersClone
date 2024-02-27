using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CollactableControl.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
