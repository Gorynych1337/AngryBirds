using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Block
{
    [SerializeField] private SoundsPreset pigDieSound;

    public delegate void EnemyHandler(GameObject enemy);
    public static EnemyHandler OnEnemyDestroyed;

    private void OnDisable()
    {
        OnEnemyDestroyed?.Invoke(gameObject);
    }

    private void OnDestroy()
    {
        SoundManager.Instance.PlaySound(pigDieSound.GetClip());
    }
}
