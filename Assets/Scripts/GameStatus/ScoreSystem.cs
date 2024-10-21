using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score { get { return _score; } }
    private int _score;

    public delegate void ScoreChanged(int score);
    public static event ScoreChanged OnScoreChanged;

    public static ScoreSystem Instance;

    private void OnEnable()
    {
        Instance = this;
        Block.OnBlockDestroyed += Instance.AddScore;
    }

    private void OnDisable()
    {
        Block.OnBlockDestroyed -= Instance.AddScore;
    }

    private void AddScore(int score)
    {
        _score += score;
        OnScoreChanged?.Invoke(_score);
    }
}
