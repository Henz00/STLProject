using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Setup()
    {
        Transform[] spawnpoints;
        spawnpoints = GameObject.Find("WolfSpawnPoints").GetComponentsInChildren<Transform>();

        foreach(GameObject child in gameObject.GetComponentInChildren<Transform>().parent)
        {
            child.transform.position = spawnpoints[Random.Range(0,spawnpoints.Length - 1)].transform.position;
            child.GetComponent<EnemyMovement>().enabled = true;
        }
    }
}
