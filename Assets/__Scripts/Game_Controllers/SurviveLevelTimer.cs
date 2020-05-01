using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurviveLevelTimer : MonoBehaviour
{
    [SerializeField] private float levelTime = 120.0f;

    public LevelCompleteUI ui;
    public GameController ctrl;
    public TextMeshProUGUI timeAmount;


    // Update is called once per frame
    void Update()
    {
        float timeLeft = levelTime - ctrl.time;
        timeAmount.SetText(timeLeft.ToString("F2"));

        if(ctrl.time > levelTime)
        {
            ui.LevelCompleted();
        }
    }
}
