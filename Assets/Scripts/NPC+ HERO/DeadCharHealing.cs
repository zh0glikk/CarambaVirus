using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCharHealing : MonoBehaviour
{
    private GameObject player;
    private Animator animator;

    private bool isAllowedToHeal = false;
    private bool isHeadled = false;
    private float magnitude;
    private float colideDistance = 2f;

    public GameObject fxRes;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (OnTrigger() && !isHeadled)
        {

            if(Input.GetKeyDown(KeyCode.E))
            {
                isHeadled = true;
                GameController.deadCharCount++;
                animator.Play("Healing");
                FindObjectOfType<AudioManager>().Play("Healing");

                fxRes.SetActive(true);
                StartCoroutine(CoolDownBeforeDestroy());
            }
        }
    }



    private bool OnTrigger()
    {
        magnitude = Mathf.Abs((transform.position - player.transform.position).magnitude); // vector length
        if (magnitude <= colideDistance)
        {
            isAllowedToHeal = true;

        }
        else
        {
            isAllowedToHeal = false;
        }
        return isAllowedToHeal;
    }



    IEnumerator CoolDownBeforeDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
