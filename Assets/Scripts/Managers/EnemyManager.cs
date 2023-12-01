using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    MiniGameManager miniGameManager;

    void Awake()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
    }
    void Start()
    {
        miniGameManager.StartGame += Setup;
    }

    public void Setup(object sender, EventArgs e)
    {
        Transform[] spawnpoints;
        spawnpoints = GameObject.Find("WolfSpawnPoints").GetComponentsInChildren<Transform>();

        foreach (Transform child in gameObject.GetComponentInChildren<Wolf>().gameObject.transform)
        {
            child.position = spawnpoints[UnityEngine.Random.Range(0, spawnpoints.Length)].position;
            child.parent.GetComponent<EnemyMovement>().enabled = true;
        }
    }

    public void GameOverState()
    {
        foreach (Transform child in gameObject.GetComponentInChildren<Wolf>().gameObject.transform)
        {
            child.parent.GetComponent<EnemyMovement>().enabled = false;
        }
    }
}
