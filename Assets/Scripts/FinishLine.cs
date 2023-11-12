using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    public event EventHandler Finished;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Sheep"))
            Finished?.Invoke(this, EventArgs.Empty);
    }
}
