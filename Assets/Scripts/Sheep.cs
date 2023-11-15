using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Sheep : MonoBehaviour
{
    private int health;
    bool invulnerable;
    public bool hasBeenEaten;
    MiniGameManager miniGameManager;

    void Awake()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
    }
    void Start()
    {
        Setup();
        invulnerable = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (!invulnerable)
            {
                Debug.Log(health.ToString());

                if (health <= 0)
                {
                    hasBeenEaten = true;
                    miniGameManager.GameLost(this, EventArgs.Empty);
                }

                health--;
                Vector2 direction = collision.gameObject.transform.position - gameObject.transform.position;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 100, ForceMode2D.Force);
                InvulnerabilityTime();
            }
            
            
        }
    }

    private void Setup()
    {
        health = 1;
        hasBeenEaten = false;
    }

    IEnumerable InvulnerabilityTime()
    {
        invulnerable = true;
        yield return new WaitForSeconds(3);
        invulnerable = false;
    }
}
