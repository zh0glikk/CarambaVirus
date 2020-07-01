using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    

    public static float time;


    void Start()
    {
        time = 0.0f;
    }

    void FixedUpdate()
    {
        TimeManager();   
    }

    void TimeManager()
    {
        if (time >= 0)
        {
            time += Time.deltaTime;
            float msec = (time - (int)(time))*100;
            int sec = (int)(time % 60);
            int min = (int)(time / 60 % 60);
            GetComponent<Text>().text = "" + min.ToString("0") + ":" + sec.ToString("00") + ":" + msec.ToString("00");
        }
        if (time <= 0)
        {
            time = 0;
            GetComponent<Text>().text = "0" + ":" + "00" + ":" + "00";
        }
    }
}
