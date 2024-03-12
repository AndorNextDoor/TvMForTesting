using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;


    private void Awake()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", -10);
        }
        //
        //
        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", -10);
        }
    }

    private void Start()
    {
        audioMixer.SetFloat("musicVolume", PlayerPrefs.GetFloat("musicVolume"));
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        //
        audioMixer.SetFloat("sfxVolume", PlayerPrefs.GetFloat("sfxVolume"));
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void MusicSliderOnValueChanged(float value)
    {
        audioMixer.SetFloat("musicVolume", value);
        PlayerPrefs.SetFloat("musicVolume", value);
    }

    public void SFXSliderOnValueChanged(float value)
    {
        audioMixer.SetFloat("sfxVolume", value);
        PlayerPrefs.SetFloat("sfxVolume", value);
    }

}
