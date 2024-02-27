using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] ground;
    public int zPos = 50;
    public bool creatingGround = false;
    public int groNum;

    void Update()
    {
        if (creatingGround == false)
        {
            creatingGround = true;
            StartCoroutine(GenerateGround());
        }
    }
    IEnumerator GenerateGround()
    {
        groNum = Random.Range(0, 5);
        Instantiate(ground[groNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(2);
        creatingGround = false;
    }


}
