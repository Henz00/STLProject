using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{

    MiniGameManager miniGameManager;


    void Awake()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
    }
    void Start()
    {
        miniGameManager.EnemyHitEvent += WasHit;
    }

    void WasHit(object sender, EventArgs e)
    {
        //gameObject.SetActive(false);
    }

}
