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

    void Awake()
    {
        text = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
        timer = gameObject.GetComponent<TimeManager>();
    }
    void Start()
    {
        points = 0;
        text.text = $"Points: {points}";
        startpoints = (int)timer.gameTime;
    }

    private void FixedUpdate()
    {
        points = 30 - (int)Mathf.Ceil(timer.gameTime);
        text.text = $"Points: {points}";
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
