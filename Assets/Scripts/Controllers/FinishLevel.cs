using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject FinishFx;
    public GameObject scenePanel;

    private void Start()
    {
        scenePanel = GameObject.FindGameObjectWithTag("panelOpening");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && GameController.deadCharCount==3)
        {
            Instantiate(FinishFx, transform.position, Quaternion.identity);
            StartCoroutine(CoolDownBeforeNextLevel());
        }
    }


    IEnumerator CoolDownBeforeNextLevel()
    {
        FindObjectOfType<AudioManager>().Play("Win");
        PlayerMoving.canMove = false;
        yield return new WaitForSeconds(2f);
        scenePanel.GetComponent<Animator>().Play("ScenePanelOpen");
        yield return new WaitForSeconds(0.4f);


        //save that the lvl was passed
        LevelController.isPassed[LevelController.levelNumberToLoad-1] = 1;

        PlayerPrefs.SetInt("isPassed" + (LevelController.levelNumberToLoad - 1), LevelController.isPassed[LevelController.levelNumberToLoad - 1]);
        PlayerPrefs.Save();

        // save best time
        if(PlayerPrefs.GetFloat("BestTime" + (LevelController.levelNumberToLoad - 1)) < Timer.time)
            PlayerPrefs.SetFloat("BestTime" + (LevelController.levelNumberToLoad - 1), Timer.time);


        LevelController.levelNumberToLoad++;
        SceneManager.LoadScene(1);
    }
}
