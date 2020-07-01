using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleShooter : MonoBehaviour
{
    private Rigidbody2D rb;


    public Vector2 ForceVelocity;
    public Quaternion quat;
    //public float angle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularDrag = 0.01f;
        rb.AddForce(ForceVelocity, ForceMode2D.Impulse);
        transform.rotation = quat;
    }

    void Update()
    {
        
    }

}
