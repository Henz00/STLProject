using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    private int health;
    public bool hasBeenEaten;
    public event EventHandler SheepWasEaten;

    void Start()
    {
        health = 1;
        hasBeenEaten = false;
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
                SheepWasEaten?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
