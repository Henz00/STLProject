using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameManager : MonoBehaviour
{

    int points;
    string gameOverSuccesText = "Good job! The sheep made it!";
    string gameOverFailedText = "Oh no! The sheep didn't make it.";

    Sheep sheep;
    GameObject GameOverMenu;
    TMP_Text GameOverMenuText;

    void Start()
    {
        sheep = GameObject.Find("Sheep").GetComponent<Sheep>();
        GameOverMenu = GameObject.Find("GameOverMenuHolder");
        GameOverMenuText = GameObject.Find("GameOverMenuText").GetComponent<TextMeshProUGUI>();


        GameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sheep.hasBeenEaten)
        {
            points = GetComponent<PointManager>().points;
            GameOverMenu.SetActive(true);
            GameOverMenuText.text = gameOverFailedText + $"\nPoints gained: {points}";
        }
    }
}
