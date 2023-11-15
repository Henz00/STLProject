using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinishLine : MonoBehaviour
{

    MiniGameManager miniGameManager;

    void Awake()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Sheep"))
            miniGameManager.GameWon(this, EventArgs.Empty);
    }
}
