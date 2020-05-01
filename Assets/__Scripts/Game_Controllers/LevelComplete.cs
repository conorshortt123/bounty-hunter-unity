using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public LevelCompleteUI ui;

    private void OnTriggerEnter2D(Collider2D playerCol)
    {
        var player = playerCol.GetComponent<CharacterController2D>();

        if (player)
        {
            Debug.Log("Level complete");
            ui.LevelCompleted();
        }
    }
}
