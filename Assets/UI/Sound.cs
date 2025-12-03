using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = backgroundMusic.volume;
    }

    void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }
}
