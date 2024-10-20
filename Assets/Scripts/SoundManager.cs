using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    public static Lazy<SoundManager> Instance = new Lazy<SoundManager>();

    public float MusicVolume { get { return musicVolume; } }
    public float SoundVolume { get { return soundVolume; } }

    private float musicVolume;
    private float soundVolume;

    private string musicKey = "Music";
    private string soundKey = "Sounds";

    public SoundManager()
    {
        musicVolume = PlayerPrefs.GetFloat(musicKey, 1f);
        soundVolume = PlayerPrefs.GetFloat(soundKey, 1f);
    }

    public void SetVolume(float sound, float music)
    {
        musicVolume = music;
        soundVolume = sound;
        PlayerPrefs.SetFloat(soundKey, sound);
        PlayerPrefs.SetFloat(musicKey, music);
        PlayerPrefs.Save();
    }
}
