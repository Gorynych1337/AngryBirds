using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hud : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private string scoreTemplate;

    private void Start()
    {
        pauseMenu.SetActive(false);
        ScoreSystem.OnScoreChanged += ChangeScoreText;
        ChangeScoreText(0);
    }

    private void OnDisable()
    {
        ScoreSystem.OnScoreChanged -= ChangeScoreText;
    }

    private void ChangeScoreText(int score)
    {
        scoreText.text = scoreTemplate + score;
    }

    public void OpenPauseMenu()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ToMainMenuClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
