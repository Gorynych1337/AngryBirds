using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundCollection", menuName = "MySO/SoundCollection", order = 1)]
public class SoundsPreset : ScriptableObject
{
    [SerializeField] private List<AudioClip> audioClips;

    public AudioClip GetClip()
    {
        if (audioClips.Count == 1) return audioClips[0];
        else
        {
            int clipPosition = Random.Range(0, audioClips.Count);
            return audioClips[clipPosition];
        }
    }
}
