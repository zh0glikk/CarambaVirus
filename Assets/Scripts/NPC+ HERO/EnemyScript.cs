using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int HealthPoints;
    public GameObject deadGameObj;


    void Start()
    {

    }

    void Update()
    {
        if (HealthPoints <= 0)
            StartCoroutine(CoolDownBeforeDestroy());
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ShotUnit"))
        {
            HealthPoints -= 1;
        }
        if (collision.gameObject.CompareTag("saw"))
        {
            HealthPoints -= 1;
        }
    }

    IEnumerator CoolDownBeforeDestroy()
    {
        Instantiate(deadGameObj, transform.position, Quaternion.identity);
        Destroy(gameObject);
        yield return new WaitForSeconds(0.1f);

    }
}
