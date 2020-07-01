using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 rotationDirection;

    void Update()
    {
        rotationDirection.z += speed;
        transform.rotation = Quaternion.Euler(rotationDirection);
    }

    

}
