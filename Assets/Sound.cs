using System;
using UnityEngine;
using UnityEngine.Audio;
using static AudioManager;

[Serializable]
public class Sound 
{

    public AudioSounds name;

    public AudioClip clip;

    public AudioMixerGroup outputGroup;

    [HideInInspector] public AudioSource source;

    [Range(0,1)]
    public float volume;
    [Range(0.1f,3)]
    public float pitch;

    public bool loop;
}
