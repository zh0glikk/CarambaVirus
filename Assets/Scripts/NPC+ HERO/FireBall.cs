using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool isCollided = false;

    private Animator animator;
    private Rigidbody2D rb;

    private Vector2 direction;


    public GameObject Hero;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // --- CHECK DIRECTION OF FIREBALL---

        if (PlayerMoving.isFacingRight)
            direction = Vector2.right;
        if (!PlayerMoving.isFacingRight)
            direction = Vector2.left;


        // --- CHECK COLLISION ON START---

        if(!isCollided)
            StartCoroutine(CoolDownBeforeAnim(3f));
        if(isCollided)
            StartCoroutine(CoolDownBeforeDestroy(1f));


        if (!isCollided)
        {
            rb.AddForce(direction * speed, ForceMode2D.Impulse);
        }

    }

    



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject)
        {
            StartCoroutine(CoolDownBeforeDestroy(1f));
            isCollided = true;
        }
    }


    IEnumerator CoolDownBeforeDestroy(float Time)
    {
        animator.Play("FxExp");
        yield return new WaitForSeconds(Time);
        Destroy(gameObject);
    }

    IEnumerator CoolDownBeforeAnim(float Time)
    {
        yield return new WaitForSeconds(Time);
        if (!isCollided)
        {
            StartCoroutine(CoolDownBeforeDestroy(1f));
        }
        
    }
}
