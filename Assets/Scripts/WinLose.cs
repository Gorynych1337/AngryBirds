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
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDestroyed -=  DeleteEnemy;
    }

    private void DeleteEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);

        if (enemies.Count == 0)
        {
            Debug.Log("Win");
        }
    }
}
