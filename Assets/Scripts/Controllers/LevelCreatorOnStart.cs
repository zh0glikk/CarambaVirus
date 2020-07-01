using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCreatorOnStart : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject[] scenes = new GameObject[15];

    [Header("Panels")]
    public GameObject panel;

    public GameObject OpeningPanel;


    public GameObject SnowBg;

    void Start()
    {
        panel.SetActive(false);
        ShowBg();
        if(LevelController.levelNumberToLoad <=10)
            Instantiate(scenes[LevelController.levelNumberToLoad - 1], transform.position, Quaternion.identity);
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Continue();
        }
        
    }

    public void Pause()
    {
        panel.SetActive(true);
        isPaused = true;
        FindObjectOfType<AudioManager>().Play("Button Click");
        Time.timeScale = 0;
    }

    public void Continue()
    {
        panel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().Play("Button Click");
    }

    public void Menu()
    {
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().Play("Button Click");
        OpeningPanel.GetComponent<Animator>().Play("ScenePanelOpen");
        StartCoroutine(CoolDownBeforeLoad());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    void ShowBg()
    {
        if (LevelController.levelNumberToLoad >= 6)
            SnowBg.SetActive(true);
        else
            SnowBg.SetActive(false);

    }


    IEnumerator CoolDownBeforeLoad()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }

}
