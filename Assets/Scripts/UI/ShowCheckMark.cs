using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCheckMark : MonoBehaviour
{
    public int number;

    private void Start()
    {
        
        LevelController.isPassed[number-1]= PlayerPrefs.GetInt("isPassed" + (number - 1));
        ShowOrHide(number);
    }

    void ShowOrHide(int number)
    {
        if (LevelController.isPassed[number - 1] == 1)
        {
            gameObject.SetActive(true);
        }
        else if(LevelController.isPassed[number-1] == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }



}
