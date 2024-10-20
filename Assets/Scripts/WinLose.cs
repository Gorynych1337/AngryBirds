using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    List<GameObject> enemies;

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
        Debug.Log(isWin ? "You win" : "You lose");
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
