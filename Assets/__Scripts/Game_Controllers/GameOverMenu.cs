using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    public TextMeshProUGUI cash;
    public TextMeshProUGUI time;
    public GameController controller;

    private string menu = "MenuScene";

    void Update()
    {
        UpdateScoreAndTime();
    }

    public void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        SceneManager.LoadScene(menu);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    private void UpdateScoreAndTime()
    {
        string cashAmount = GameController.playerScore.ToString();
        string timeAmount = controller.time.ToString("F2");

        cash.SetText("$" + cashAmount);
        time.SetText(timeAmount);
    }
}
