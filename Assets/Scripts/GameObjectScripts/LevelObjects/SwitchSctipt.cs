using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSctipt : MonoBehaviour
{
    private Animator anim;
    public GameObject platform;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("gameObjFriendly"))
        {
            anim.Play("Switch");
            platform.GetComponent<ObjectsMovingPatrol>().enabled = true;
        }
    }
}
