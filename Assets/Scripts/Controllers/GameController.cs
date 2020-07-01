using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int deadCharCount;

    public GameObject DeadCharGO;
    public GameObject hero;
    public GameObject scenePanel;

    private GameObject respawn;

    private bool canPlayLooseSound = true;

    private void Awake()
    {
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().Play("Main Theme");

        DeadCharGO = GameObject.FindGameObjectWithTag("countTetx");
        
        scenePanel = GameObject.FindGameObjectWithTag("panelOpening");
        scenePanel.GetComponent<Animator>().Play("ScenePanelClose");

        respawn = GameObject.FindGameObjectWithTag("Respawn");
        if (hero != null)
            Instantiate(hero, respawn.transform.position, Quaternion.identity);
    }

    void Start()
    {
        deadCharCount = 0;
    }

    void Update()
    {
        if (!PlayerMoving.isAlive)
        {
            StartCoroutine(IsGoingToDie());
        }
        DeadCharGO.GetComponent<Text>().text = deadCharCount + "/3";
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator IsGoingToDie()
    {
        if (canPlayLooseSound)
        {
            FindObjectOfType<AudioManager>().StopPlaying("Main Theme");
            FindObjectOfType<AudioManager>().Play("Loose");
            canPlayLooseSound = false;
        }
        yield return new WaitForSeconds(0.3f);
        scenePanel.GetComponent<Animator>().Play("ScenePanelOpen");
        yield return new WaitForSeconds(0.5f);
        RestartGame();
    }

}
