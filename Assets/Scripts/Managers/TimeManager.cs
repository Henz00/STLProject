using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float gameTime;
    public TMP_Text text;
    private Sheep sheep;

    void Awake()
    {
        //text = GameObject.Find("GameTimer").GetComponent<TextMeshProUGUI>();
        sheep = GameObject.Find("Sheep").GetComponent<Sheep>();
        gameTime = 30;
    }


    //void FixedUpdate()
    //{
    //    if (!sheep.hasBeenEaten)
    //    {
    //        if (gameTime >= 0)
    //        {
    //            gameTime -= Time.deltaTime;
    //            text.text = $"Time left: {Mathf.Ceil(gameTime)}";
    //        }
    //        else
    //            text.text = $"Game over!";
    //    } 
    //    else
    //        text.text = $"Game over!";
    //}
}
