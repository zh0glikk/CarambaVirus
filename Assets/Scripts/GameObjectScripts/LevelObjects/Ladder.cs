using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 0;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                collision.gameObject.GetComponent<Animator>().Play("Run");
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2 * speed);
                collision.gameObject.GetComponent<Animator>().Play("Run");
            }
            else
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
    }
}
