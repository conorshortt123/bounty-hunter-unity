using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCompleteUI : MonoBehaviour
{
    public GameObject levelCompleteUI;
    public TextMeshProUGUI cash;
    public TextMeshProUGUI time;
    public TextMeshProUGUI spm;
    public GameController controller;

    private string menu = "MenuScene";

    void Update()
    {
        UpdateScoreAndTime();
    }

    public void LevelCompleted()
    {
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        SceneManager.LoadScene(menu);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        float scorePerMin = (GameController.playerScore / controller.time) * 60;
        string spmText = scorePerMin.ToString();

        cash.SetText("$" + cashAmount);
        time.SetText(timeAmount);
        spm.SetText(spmText);
    }
}
