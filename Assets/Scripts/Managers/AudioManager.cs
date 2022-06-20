using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;


    override protected void Init()
    {
        foreach (Sound s in sounds) // Create AudioSource components from Sounds[] array
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    /// <summary>
    /// Returns a Sound from the AudioManager.Sounds[] array using Array.Find
    /// </summary>
    private Sound FindSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound with name: " + name + " could not be found.");
            s = FindSound("Error");
        }
        return s;
    }


    public void Play(string name)
    {
        Sound s = FindSound(name);
        s.source.Play();
    }


    public void SetPitch(string name, float pitch)
    {
        Sound s = FindSound(name);
        s.source.pitch = pitch;
    }
}
