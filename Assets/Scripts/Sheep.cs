using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public bool hasBeenEaten;
    public event EventHandler SheepWasEaten;

    void Start()
    {
        hasBeenEaten = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            hasBeenEaten = true;
            SheepWasEaten?.Invoke(this, EventArgs.Empty);
        }
    }
}
