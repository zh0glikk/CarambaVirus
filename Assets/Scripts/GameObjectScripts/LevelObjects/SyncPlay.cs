using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPlay : MonoBehaviour
{
    private bool canPlayAgain = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canPlayAgain)
        {
            gameObject.GetComponent<Animator>().Play("syncPlay");
            FindObjectOfType<AudioManager>().Play("Sync Theme");
            StartCoroutine(CoolDownBeforeNextPlay());
        }
    }


    IEnumerator CoolDownBeforeNextPlay()
    {
        canPlayAgain = false;
        yield return new WaitForSeconds(13f);
        canPlayAgain = true;
    }
}
