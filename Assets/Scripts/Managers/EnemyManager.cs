using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    MiniGameManager miniGameManager;

    void Start()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
        miniGameManager.Setup += Setup;
    }

    void Setup(object sender, EventArgs e)
    {
        Transform[] spawnpoints;
        spawnpoints = GameObject.Find("WolfSpawnPoints").GetComponentsInChildren<Transform>();

        foreach (GameObject child in gameObject.GetComponentInChildren<Transform>().parent)
        {
            child.transform.position = spawnpoints[UnityEngine.Random.Range(0, spawnpoints.Length - 1)].transform.position;
            child.GetComponent<EnemyMovement>().enabled = true;
        }
    }
}
