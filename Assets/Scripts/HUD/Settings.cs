using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundsSlider;

    private void OnEnable()
    {
        musicSlider.value = SoundManager.Instance.Value.MusicVolume;
        soundsSlider.value = SoundManager.Instance.Value.SoundVolume;
    }

    public void SaveSettings()
    {
        SoundManager.Instance.Value.SetVolume(soundsSlider.value, musicSlider.value);
        gameObject.SetActive(false);
    }
}
