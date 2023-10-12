using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    int points;
    private TMP_Text text;

    void Start()
    {
        points = 0;
        text = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
        text.text = $"Points: {points}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Another point for Icon!");
            points++;
            text.text = $"Points: {points}";
        }
    } 
}
