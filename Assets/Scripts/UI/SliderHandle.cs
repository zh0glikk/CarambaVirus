using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandle : MonoBehaviour
{
    Slider sl;

    void Start()
    {

        sl = GetComponent<Slider>();
        if(PlayerPrefs.GetString("isSaved")=="true")
            sl.value = PlayerPrefs.GetFloat("sliderValue");
    }


    public void ChangeVolume()
    {
        AudioListener.volume = sl.value;
        PlayerPrefs.SetFloat("sliderValue", sl.value);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("isSaved", "true");
    }
}
