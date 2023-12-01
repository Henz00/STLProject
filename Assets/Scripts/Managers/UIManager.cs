using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    MiniGameManager miniGameManager;
    TMP_Text GameOverMenuText;
    PointManager pointManager;

    string gameOverSuccesText = "Good job! The sheep made it!";
    string gameOverFailedText = "Oh no! The sheep didn't make it.";

    Dictionary<string, string> nextLevelPairs = new Dictionary<string, string>()
    {
        { "SheepHerdingLEVEL1", "SheepHerdingLEVEL2GrassTest" },
        { "SheepHerdingLEVEL2GrassTest", "SheepHerdingLEVEL3" },
    };

    void Awake()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
        GameOverMenuText = GameObject.Find("GameOverMenuText").GetComponent<TextMeshProUGUI>();
        pointManager = GameObject.Find("GameManager").GetComponent<PointManager>();
    }
    void Start()
    {
        miniGameManager.GameOverEvent += UpdateTextGameOver;
        miniGameManager.GameWonEvent += UpdateTextGameWon;
    }

    void UpdateTextGameOver(object sender, EventArgs e)
    {
        GameOverMenuText.text = gameOverFailedText;
    }

    void UpdateTextGameWon(object sender, EventArgs e)
    {
        GameOverMenuText.text = gameOverSuccesText;
    }

    public void RestartLevel()
    {
        miniGameManager.GameSetup(this, EventArgs.Empty);
    }

    public void Continue()
    {
        string name = SceneManager.GetActiveScene().name;
        string nextlevel;
        nextLevelPairs.TryGetValue(name, out nextlevel);
        LoadLevel(nextlevel);
    }
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
