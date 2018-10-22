using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class AudioManager : MonoBehaviour
{
    AudioSource[] audioFiles;
    [SerializeField]
    AudioSource test;
    float volume;
    bool soundMuted;
    public delegate void _ChangeVolume(float value);
    public _ChangeVolume ChangeVolume;

    void Start()
    {
        audioFiles = FindObjectsOfType<AudioSource>();
        ChangeVolume += SetVolume;
        ChangeVolume += UnMute;
    }

    public AudioSource[] GetAudioSources()
    {
        return audioFiles;
    }

    void UnMute(float ignore)
    {
        soundMuted = false;
    }

    void SetVolume(float volume)
    {
        Debug.Log(audioFiles.Length);
        for(int i = 0; i < audioFiles.Length; i++)
        {
            audioFiles[i].volume = volume;
        }
        this.volume = volume;
    }

    public bool ToggleMute()
    {
        soundMuted = !soundMuted;
        if(!soundMuted)
        {
            for(int i = 0; i < audioFiles.Length; i++)
            {
                audioFiles[i].volume = volume;
            }
            return false;
        }
        else
        {
            if(audioFiles.Count() > 1)
                volume = audioFiles[0].volume;
            for(int i = 0; i < audioFiles.Length; i++)
            {
                audioFiles[i].volume = 0;
            }
            return true;
        }   
    }

    public bool GetSoundMuted()
    {
        return soundMuted;
    }

    //public AudioSource[] GetAudio()
    //{
    //    return audioFiles;
    //}
}
