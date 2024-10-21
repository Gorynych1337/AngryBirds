using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private SoundsPreset buttonSound;

    public void OnClick()
    {
        SoundManager.Instance.PlaySound(buttonSound.GetClip());
    }
}
