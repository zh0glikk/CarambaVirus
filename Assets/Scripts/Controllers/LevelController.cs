using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int levelNumberToLoad;
    public GameObject panel;

    public static int[] isPassed = new int[10];

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Main Theme");
        //FindObjectOfType<AudioManager>().StopPlaying("Sync Theme");

        panel = GameObject.FindGameObjectWithTag("panelOpening");
        levelNumberToLoad = 1;
        panel.GetComponent<Animator>().Play("ScenePanelClose");
    }

    public void OnClickLoad(int levelNumber)  // load level when u click the btn
    {
        levelNumberToLoad = levelNumber;
        panel.GetComponent<Animator>().Play("ScenePanelOpen");
        FindObjectOfType<AudioManager>().Play("Button Click");
        StartCoroutine(CoolDownBeforeLoad());
        
    }

    IEnumerator CoolDownBeforeLoad()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }


    
}
