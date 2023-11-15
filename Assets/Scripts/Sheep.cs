using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    private int health;
    public bool hasBeenEaten;
    MiniGameManager miniGameManager;

    void Awake()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
    }
    void Start()
    {
        Setup();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            health--;
            Debug.Log(health.ToString());

            if(health <= 0)
            {
                hasBeenEaten = true;
                miniGameManager.GameLost(this, EventArgs.Empty);
            }
        }
    }

    private void Setup()
    {
        health = 1;
        hasBeenEaten = false;
    }
}
