using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    MiniGameManager miniGameManager;

    public float moveSpeed = 5f;
    public float waitTime = 3f;
    public Animator animator;
    private GameObject sheep;
    private SpriteRenderer spriteRenderer;
    private float previousPosition;

    private bool isHit = false;

    void Awake()
    {
        sheep = GameObject.Find("Sheep");
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousPosition = transform.position.x;
    }


    void Update()
    {
        animator.SetFloat("Speed", moveSpeed);

        if (!isHit)
            MoveToTarget(GameObject.Find("Sheep").GetComponent<Transform>());
        
        float currentPosition = transform.position.x;
        
        if (currentPosition > previousPosition)
        {
            spriteRenderer.flipX = true;
        }
        else if (currentPosition < previousPosition)
        {
            spriteRenderer.flipX = false;
        }
        previousPosition = currentPosition;
    }

    void MoveToTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        if (direction.magnitude > 0.1f)
            transform.Translate(moveSpeed * Time.deltaTime * direction.normalized);
    }
}