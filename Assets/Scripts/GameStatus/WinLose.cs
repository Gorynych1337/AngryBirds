using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    List<GameObject> enemies;

    public delegate void GameEndDelegate(bool isWin);
    public static event GameEndDelegate OnGameEnd;

    private void Awake()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        Enemy.OnEnemyDestroyed += DeleteEnemy;
        BirdQueue.OnQueueEnded += () => EndGame(false);
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDestroyed -=  DeleteEnemy;
    }

    private void EndGame(bool isWin)
    {
        OnGameEnd?.Invoke(isWin);
    }

    private void DeleteEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);

        if (enemies.Count == 0)
        {
            EndGame(true);
        }
    }
}
