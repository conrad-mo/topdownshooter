using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LogicScript : MonoBehaviour
{
    public static LogicScript instance;

    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    public bool GameIsOver { get; private set; }
    
    
    private void Start()
    {
        instance = this;
    }

    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        GameIsOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
