using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleFactory : MonoBehaviour
{
    public GameObject Icicle;

    void Start()
    {
        StartCoroutine(IcicleSpawner());
    }


    IEnumerator IcicleSpawner()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            Instantiate(Icicle,transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
