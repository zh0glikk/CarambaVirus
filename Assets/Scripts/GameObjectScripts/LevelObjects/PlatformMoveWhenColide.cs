using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveWhenColide : MonoBehaviour
{
    private SliderJoint2D sl;

    private void Start()
    {
        sl = gameObject.GetComponent<SliderJoint2D>();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sl.enabled = true;
        }
    }
}
