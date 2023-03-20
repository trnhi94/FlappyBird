using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : Singleton<AudioController>
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip[] sfxClips;

    public void PlaySfx(string name)
    {
        var sfx = Array.Find(sfxClips, x => x.name == name);
        if(sfx == null)
        {
            return;
        }
        else
        {
            sfxSource.PlayOneShot(sfx); 
        }
    }
}

