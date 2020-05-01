using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    //== public fields ==
    static public int playerScore = 0;
    public float time;

    [SerializeField] private TextMeshProUGUI scoreText;

    // == public methods ==
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            time += Time.deltaTime;
        }
    }

    // == private methods ==
    private void OnEnable()
    {
        Enemy.EnemyKilledEvent += OnEnemyKilledEvent;
    }
    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= OnEnemyKilledEvent;
    }

    private void OnEnemyKilledEvent(Enemy enemy)
    {
        // add the score value for the enemy to the player score
        playerScore += enemy.ScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = playerScore.ToString();
    }
}
