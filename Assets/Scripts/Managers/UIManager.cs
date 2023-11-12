using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    TMP_Text GameOverMenuText;

    string gameOverSuccesText = "Good job! The sheep made it!";
    string gameOverFailedText = "Oh no! The sheep didn't make it.";

    void Start()
    {
        GameOverMenuText = GameObject.Find("GameOverMenuText").GetComponent<TextMeshProUGUI>();
    }

    void UpdateText(string text)
    {
        GameOverMenuText.text = text + $"\nPoints gained: ";
    }


}
