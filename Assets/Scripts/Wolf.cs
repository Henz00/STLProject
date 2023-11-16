using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{

    MiniGameManager miniGameManager;
    public Animator animator;

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
        animator.SetTrigger("GetHit");
    }

}
