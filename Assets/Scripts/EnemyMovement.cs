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

    private bool isHit = false;

    void Awake()
    {
        sheep = GameObject.Find("Sheep");
    }


    void Update()
    {
        animator.SetFloat("Speed", moveSpeed);

        if (!isHit)
            MoveToTarget(GameObject.Find("Sheep").GetComponent<Transform>());

    }

    void MoveToTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        if (direction.magnitude > 0.1f)
            transform.Translate(moveSpeed * Time.deltaTime * direction.normalized);
    }
}