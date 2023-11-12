using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MiniGameManager : MonoBehaviour
{
    public bool gameActive;
    int points;
    string gameOverSuccesText = "Good job! The sheep made it!";
    string gameOverFailedText = "Oh no! The sheep didn't make it.";

    FinishLine finish;
    Sheep sheep;
    EnemyMovement wolf;
    GameObject SheepHerder;
    GameObject GameOverMenu;
    TMP_Text GameOverMenuText;

    void Start()
    {
        finish = GameObject.Find("SheepTargetPoint").GetComponent<FinishLine>();
        sheep = GameObject.Find("Sheep").GetComponent<Sheep>();
        wolf = GameObject.Find("Wolf").GetComponent<EnemyMovement>();
        SheepHerder = GameObject.Find("Sheepherder");

        GameOverMenu = GameObject.Find("GameOverMenuHolder");
        GameOverMenuText = GameObject.Find("GameOverMenuText").GetComponent<TextMeshProUGUI>();

        sheep.SheepWasEaten += SheepHasBeenEaten;
        finish.Finished += SheepHasMadeIt;

        GameSetup();
    }

    void SheepHasBeenEaten(object sender, EventArgs e)
    {
        GameOverMenuText.text = gameOverFailedText + $"\nPoints gained: {points}";
        FinishGame();
    }

    void SheepHasMadeIt(object sender, EventArgs e)
    {
        GameOverMenuText.text = gameOverSuccesText + $"\nPoints gained: {points}";
        FinishGame();
    }

    void FinishGame()
    {
        gameActive = false;
        points = GetComponent<PointManager>().points;
        GameOverMenu.SetActive(true);
        wolf.enabled = false;
    }

    public void GameSetup()
    {
        Transform[] spawnpoints;
        spawnpoints = GameObject.Find("WolfSpawnPoints").GetComponentsInChildren<Transform>();
        wolf.gameObject.transform.position = spawnpoints[UnityEngine.Random.Range(0, 3)].position;

        sheep.gameObject.transform.position = GameObject.Find("SheepSpawnPoint").GetComponent<Transform>().position;
        SheepHerder.transform.position = GameObject.Find("PlayerSpawnPoint").GetComponent<Transform>().position;

        sheep.hasBeenEaten = false;
        wolf.enabled = true;
        gameActive = true;
        GameOverMenu.SetActive(false);
    }
}
