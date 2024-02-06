using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider allsoundsSlider;
    public AudioMixerGroup music;
    public AudioMixerGroup sfx;
    public AudioMixer allsounds;


    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        allsoundsSlider.value = PlayerPrefs.GetFloat("allsoundsVolume");
    }

    public void SetSFXSlider(float sliderValue)
    {
        sfx.audioMixer.SetFloat("VolumeSFX", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sliderValue);
    }

    public void SetMusicSlider(float sliderValue)
    {
        music.audioMixer.SetFloat("VolumeMusic", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("musicVolume", sliderValue);
    }

    public void SetallsoundsSlider(float sliderValue)
    {
        allsounds.SetFloat("VolumeMaster", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("allsoundsVolume", sliderValue);
    }
}

