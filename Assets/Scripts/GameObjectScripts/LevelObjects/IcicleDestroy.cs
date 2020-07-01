using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleDestroy : MonoBehaviour
{
    Animator anim;
    public float cd;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(CoolDownBeforeDestroyFromStart());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject!=null)
            StartCoroutine(CoolDownBeforeDestroy());
    }

    IEnumerator CoolDownBeforeDestroy()
    {
        anim.Play("DestroyIcicle");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    IEnumerator CoolDownBeforeDestroyFromStart()
    {
        yield return new WaitForSeconds(cd);
        Destroy(gameObject);
    }
}
