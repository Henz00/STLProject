using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MiniGameManager : MonoBehaviour
{
    public bool gameActive;
    int points;

    public event EventHandler GameWonEvent;
    public event EventHandler StartGame;
    public event EventHandler GameOverEvent;
    public event EventHandler Setup;
    public event EventHandler EnemyHitEvent;

    GameObject player;
    GameObject GameOverMenu;
    FinishLine finish;
    Sheep sheep;
    GameObject SheepHerder;
    EnemyManager enemyManager;

    void Awake()
    {
        finish = GameObject.Find("SheepTargetPoint").GetComponent<FinishLine>();
        sheep = GameObject.Find("Sheep").GetComponent<Sheep>();
        player = GameObject.Find("Sheepherder");
        GameOverMenu = GameObject.Find("GameOverMenuHolder");
        SheepHerder = GameObject.Find("Sheepherder");
        try
        {
            enemyManager = GameObject.Find("WolfPack").GetComponent<EnemyManager>();
        }
        catch (Exception e)
        {
            Debug.Log("No enemies in this level");
        }
        
    }
    void Start()
    {
        SetupEvents();
        Setup += GameSetup;
        Setup?.Invoke(this, EventArgs.Empty);
    }

    public void GameLost(object sender, EventArgs e)
    {
        GameOverEvent?.Invoke(sender, e);
    }

    public void GameWon(object sender, EventArgs e)
    {
        GameWonEvent?.Invoke(sender, e);
    }

    public void EnemyHit(object sender, EventArgs e)
    {
        EnemyHitEvent?.Invoke(sender, e);
    }

    void FinishGame(object sender, EventArgs e)
    {
        gameActive = false;
        player.GetComponent<PlayerMovement>().enabled = false;

        if(!enemyManager == null)
            enemyManager.GameOverState();
            
        points = GetComponent<PointManager>().points;
        GameOverMenu.SetActive(true);
    }

    public void GameSetup(object sender, EventArgs e)
    {
        gameActive = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        GameOverMenu.SetActive(false);
        sheep.gameObject.transform.position = GameObject.Find("SheepSpawnPoint").GetComponent<Transform>().position;
        SheepHerder.transform.position = GameObject.Find("PlayerSpawnPoint").GetComponent<Transform>().position;

        StartGame?.Invoke(sender, e);
    }

    //Method for setting up events, all events should lead to/start from here. Having all events be tied to the MiniGameManager class makes future referencing in the code much cleaner
    void SetupEvents()
    {
        //Chaining together the sheep being eaten event, and then starting the gamelost event from here (which all other classes should subscribe to if they need to do something when gamelost event happens)
        GameOverEvent += FinishGame;

        //Chaining together the sheep reaching the finish line event
        GameWonEvent += FinishGame;
    }
}
