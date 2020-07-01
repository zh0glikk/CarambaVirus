using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpSpeed;

    public static bool isFacingRight = true;

    float horizontal=0;

    private int healthpoints = 1;

    private bool isGrounded = false;
    private bool isMovingAndShoot = false;

    private bool isAllowedToCast = true;

    private Animator animator;
    private Rigidbody2D rb;


    public static bool isAlive = true;
    public static bool canMove = true;

    public GameObject FireBall;
    public GameObject CreateOnThisGOTransform;

    public Transform groundCheckPoint;
    public float groundCheckRadius;

    public LayerMask groundLayer;


    public AudioSource jump;

    void Start()
    {
        isAlive = true;
        canMove = true;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

       
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        if (isAlive && canMove)
        {
            FireBallCreate();
            Move();
            Jump();
        }
    }

    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            transform.position += new Vector3(1, 0, 0) * speed;
            isFacingRight = true;

            if (!isMovingAndShoot)
                animator.Play("Run");

            Flip();

        }
        if (horizontal<0)
        {
            transform.position += new Vector3(-1, 0, 0) * speed;
            isFacingRight = false;

            if (!isMovingAndShoot)
                animator.Play("Run");
            Flip();

        }
    }

    void Flip()
    {
        Vector3 Scale = transform.localScale;

        if (isFacingRight)
        {
            Scale.x = Mathf.Abs(Scale.x);
        }
        if (!isFacingRight && Scale.x > 0)
        {
            Scale.x *= -1;
        }
        transform.localScale = Scale;

    }

    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical")>0) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            //Don't play anim if space was pressed -> Shoot anim will play in FireBallCreate()
            if (isAllowedToCast)
            {
                animator.Play("Jump");
                FindObjectOfType<AudioManager>().Play("Jump");

            }
            isGrounded = false;
        }

    }

    void FireBallCreate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAllowedToCast)
        {
            isAllowedToCast = false;

            //--- CHECK WHICH ANIMATION PLAY
            if (horizontal != 0)
            {
                isMovingAndShoot = true;
            }


            if (!isMovingAndShoot && horizontal == 0 || !isGrounded)
            {
                animator.Play("Shoot");
            }
            if (isMovingAndShoot)
            {
                animator.Play("ShootAndRun");
            }


            

            StartCoroutine(CoolDownBeforeShoot(0.4f));
            

            StartCoroutine(CoolDownBeforeNextFireBall(0.8f));
        }
        


    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("saw"))
        {
            animator.Play("Damagged");
            healthpoints--;
            rb.velocity = new Vector2(transform.position.x- other.gameObject.transform.position.x,
                                      transform.position.y - other.gameObject.transform.position.y) * 10f;
            if (healthpoints <= 0)
            {
                isAlive = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        //    isGrounded = true;


        if (collision.gameObject.CompareTag("saw"))
        {
            animator.Play("Damagged");
            healthpoints--;
            rb.velocity = new Vector2(transform.position.x - collision.gameObject.transform.position.x,
                                      transform.position.y - collision.gameObject.transform.position.y) * 10f;
            if (healthpoints <= 0)
            {

                isAlive = false;
            }
        }

    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
    //        isGrounded = true;
    //}

    //bool CheckGround()
    //{

    //    Vector2 position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    //    Vector2 direction = Vector2.down;
    //    float distance = 0.6f;

    //    Debug.DrawRay(position, direction, Color.green);
        
    //    RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
    //    if (hit.collider != null)
    //    {
    //        return true;
    //    }

    //    return false;
    //}


    IEnumerator CoolDownBeforeNextFireBall(float Time)
    {
        yield return new WaitForSeconds(Time);
        isAllowedToCast = true;
        isMovingAndShoot = false;
    }


    IEnumerator CoolDownBeforeShoot(float Time)
    {
        yield return new WaitForSeconds(Time);
        FindObjectOfType<AudioManager>().Play("Shoot");
        Instantiate(
                FireBall,
                new Vector3(CreateOnThisGOTransform.transform.position.x + (transform.localScale.x / Mathf.Abs(transform.localScale.x)) / 1.6f,
                    CreateOnThisGOTransform.transform.position.y,
                    CreateOnThisGOTransform.transform.position.z),
                Quaternion.identity);


    }


   


}
