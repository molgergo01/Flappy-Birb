using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuVolumeSlider : MonoBehaviour
{

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat("Volume", (float)0.2);
        GetComponent<Slider>().value = volume;
    }

    void Update()
    {
        float volume = PlayerPrefs.GetFloat("Volume", (float)0.2);
        float sliderValue = GetComponent<Slider>().value;

        if (volume != sliderValue)
        {
            PlayerPrefs.SetFloat("Volume", sliderValue);
            PlayerPrefs.Save();
        }
    }
}
