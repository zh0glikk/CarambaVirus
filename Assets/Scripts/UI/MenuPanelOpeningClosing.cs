using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanelOpeningClosing : MonoBehaviour
{
    public GameObject Panel;
    private Animator anim;

    void Start()
    {
        Time.timeScale = 1;
        anim = Panel.GetComponent<Animator>();

        
    }


    public void OpenPanel()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");

            anim.SetBool("open", !isOpen);
            
        }
    }


    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");
        Application.Quit();
    }



}
