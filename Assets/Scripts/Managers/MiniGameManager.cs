using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MiniGameManager : MonoBehaviour
{
    public bool gameActive;
    int points;

    public event EventHandler StartGame;
    public event EventHandler GameOver;
    public event EventHandler Setup;

    GameObject GameOverMenu;
    FinishLine finish;
    Sheep sheep;
    GameObject SheepHerder;


    void Start()
    {
        finish = GameObject.Find("SheepTargetPoint").GetComponent<FinishLine>();
        sheep = GameObject.Find("Sheep").GetComponent<Sheep>();

        GameOverMenu = GameObject.Find("GameOverMenuHolder");
        SheepHerder = GameObject.Find("Sheepherder");

        sheep.SheepWasEaten += GameLost;
        finish.Finished += GameWon;
        Setup += GameSetup;
    }

    void GameLost(object sender, EventArgs e)
    {
        GameOver?.Invoke(this, EventArgs.Empty);
        FinishGame();
    }

    void GameWon(object sender, EventArgs e)
    {
        GameOver?.Invoke(this, EventArgs.Empty);
        FinishGame();
    }

    void FinishGame()
    {
        gameActive = false;
        points = GetComponent<PointManager>().points;
        GameOverMenu.SetActive(true);
    }

    public void GameSetup(object sender, EventArgs e)
    {
        gameActive = true;
        GameOverMenu.SetActive(false);
        sheep.gameObject.transform.position = GameObject.Find("SheepSpawnPoint").GetComponent<Transform>().position;
        SheepHerder.transform.position = GameObject.Find("PlayerSpawnPoint").GetComponent<Transform>().position;

        StartGame?.Invoke(this, EventArgs.Empty);
    }
}
