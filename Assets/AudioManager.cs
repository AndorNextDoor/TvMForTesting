using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject objectToAddSounds;
    
    public Sound[] sounds;


    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = objectToAddSounds.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.outputGroup;
        }
    }


    public void PlaySound(AudioSounds name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Couldn't find sound name: " + name);
            return;
        }
        s.source.PlayOneShot(s.source.clip);
    }

    public enum AudioSounds
    {
        CanonShoot,
        bedtimeBuddy,
        Insolent_Pufferfish
    }

}
