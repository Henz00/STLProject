using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float gameTime;
    private TMP_Text text;

    void Start()
    {
        text = GameObject.Find("GameTimer").GetComponent<TextMeshProUGUI>();
        gameTime = 30;
    }


    void FixedUpdate()
    {
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            text.text = $"Time left: {Mathf.Ceil(gameTime)}";
        } 
        else
        {
            text.text = $"Game over!";
        }
    }
}
