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
        musicSlider.value = SoundManager.Instance.MusicVolume;
        soundsSlider.value = SoundManager.Instance.SoundVolume;
    }

    public void SaveSettings()
    {
        SoundManager.Instance.SaveVolume(soundsSlider.value, musicSlider.value);
        gameObject.SetActive(false);
    }
}
