using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinLosePage : MonoBehaviour
{
    [Header("Header text")]
    [SerializeField] private TMP_Text header;
    [SerializeField] private string WinString;
    [SerializeField] private string LoseString;
    [Header("Score text")]
    [SerializeField] private TMP_Text score;
    [SerializeField] private string ScoreString;

    public void Instantiate(bool isWin)
    {
        header.text = isWin ? WinString : LoseString;
        score.text = ScoreString + ScoreSystem.Instance.Score;
    }
}
