using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnLoad : MonoBehaviour
{
    [SerializeField] private SoundsPreset preset;

    private void Start()
    {
        SoundManager.Instance.PlayMusic(preset.GetClip());
    }
}
