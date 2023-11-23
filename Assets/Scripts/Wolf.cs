using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{

    MiniGameManager miniGameManager;
    public Animator animator;
    public bool isStunned;
    public AudioSource hit;

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
        stunTimer(2f);
        hit.Play();
    }

    private IEnumerator stunTimer(float stuntime)
    {
        isStunned = true;
        yield return new WaitForSeconds(stuntime);
        isStunned = false;
    }

}
