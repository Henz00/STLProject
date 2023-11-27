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
    private EnemyMovement movement;

    void Awake()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
        movement = gameObject.GetComponent<EnemyMovement>();
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
        movement.moveSpeed += 1f;
    }

    private IEnumerator stunTimer(float stuntime)
    {
        isStunned = true;
        yield return new WaitForSeconds(stuntime);
        isStunned = false;
    }

}
