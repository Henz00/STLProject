using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int points;
    private TMP_Text text;
    private TimeManager timer;
    int startpoints;

    void Start()
    {
        points = 0;
        text = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
        text.text = $"Points: {points}";
        timer = gameObject.GetComponent<TimeManager>();
        startpoints = (int)timer.gameTime;
    }

    private void FixedUpdate()
    {
        text.text = $"Points: {30 - (int)Mathf.Ceil(timer.gameTime)}";
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log("Another point for Icon!");
    //        points++;
    //        text.text = $"Points: {points}";
    //    }
    //} 
}
