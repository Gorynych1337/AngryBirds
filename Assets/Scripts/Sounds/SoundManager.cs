using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundSource;

    public float MusicVolume { get { return musicVolume; } }
    public float SoundVolume { get { return soundVolume; } }

    private float musicVolume;
    private float soundVolume;

    private string musicKey = "Music";
    private string soundKey = "Sounds";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
        SetVolume(PlayerPrefs.GetFloat(soundKey, 1f), PlayerPrefs.GetFloat(musicKey, 1f));
    }

    private void SetVolume(float sound, float music)
    {
        soundVolume = sound;
        musicVolume = music;

        soundSource.volume = soundVolume;
        musicSource.volume = musicVolume;
    }

    public void SaveVolume(float sound, float music)
    {
        SetVolume(sound, music);
        PlayerPrefs.SetFloat(soundKey, sound);
        PlayerPrefs.SetFloat(musicKey, music);
        PlayerPrefs.Save();
    }

    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
}
