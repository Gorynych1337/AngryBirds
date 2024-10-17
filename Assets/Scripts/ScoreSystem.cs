using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int _score;

    public delegate void ScoreChanged(int score);
    public static event ScoreChanged OnScoreChanged;

    private void OnEnable()
    {
        Block.OnBlockDestroyed += AddScore;
    }

    private void OnDisable()
    {
        Block.OnBlockDestroyed -= AddScore;
    }

    private void AddScore(int score)
    {
        _score += score;
    }
}
