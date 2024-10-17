using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Block
{
    public delegate void EnemyHandler(GameObject enemy);
    public static EnemyHandler OnEnemyDestroyed;

    private void OnDisable()
    {
        OnEnemyDestroyed?.Invoke(gameObject);
    }
}
