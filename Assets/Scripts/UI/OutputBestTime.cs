using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputBestTime : MonoBehaviour
{
    public int number;

    void Start()
    {
        float time = PlayerPrefs.GetFloat("BestTime" + (number - 1));

        float msec = (time - (int)(time)) * 100;
        int sec = (int)(time % 60);
        int min = (int)(time / 60 % 60);
        GetComponent<Text>().text = "" + min.ToString("0") + ":" + sec.ToString("00") + ":" + msec.ToString("00");

    }

}
