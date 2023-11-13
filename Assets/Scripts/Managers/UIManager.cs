using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    MiniGameManager miniGameManager;
    TMP_Text GameOverMenuText;
    PointManager pointManager;

    string gameOverSuccesText = "Good job! The sheep made it!";
    string gameOverFailedText = "Oh no! The sheep didn't make it.";

    void Start()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
        GameOverMenuText = GameObject.Find("GameOverMenuText").GetComponent<TextMeshProUGUI>();
        pointManager = GameObject.Find("GameManager").GetComponent<PointManager>();

        miniGameManager.GameOverEvent += UpdateTextGameOver;
        miniGameManager.GameWonEvent += UpdateTextGameWon;
    }

    void UpdateTextGameOver(object sender, EventArgs e)
    {
        GameOverMenuText.text = gameOverFailedText + $"\nPoints gained: {pointManager.points}";
    }

    void UpdateTextGameWon(object sender, EventArgs e)
    {
        GameOverMenuText.text = gameOverSuccesText + $"\nPoints gained: {pointManager.points}";
    }


}
