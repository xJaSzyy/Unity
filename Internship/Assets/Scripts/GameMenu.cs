using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;

    [SerializeField] private TMP_Text scoreCountText;
    [SerializeField] private TMP_Text totalScoreCountText;
    [SerializeField] private GameObject gameOverScreen;

    private int scoreCount = 0;

    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        totalScoreCountText.text = scoreCountText.text;

        if (scoreCount > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", scoreCount);
        }

        gameOverScreen.SetActive(true);
    }

    public void RestartButtonOnClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnButtonOnClick()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void AddCount()
    {
        scoreCount++;
        scoreCountText.text = $"Score: {scoreCount}";
    }
}
