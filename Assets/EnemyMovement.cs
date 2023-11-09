using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform targetObject;
    public float moveSpeed = 5f;
    public float waitTime = 3f;
    public Animator animator;

    private bool isHit = false;

    void Update()
    {
        animator.SetFloat("Speed", moveSpeed);
        if (!isHit)
        {
            MoveTowardsTarget();
        }

        if (Input.GetButtonDown("AttackButton")) 
        {
            StopAllCoroutines(); 
            isHit = true;
            moveSpeed = 0;
            StartCoroutine(ResumeMovement());
        }
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetObject.position, moveSpeed * Time.deltaTime);
    }

    IEnumerator ResumeMovement()
    {
        yield return new WaitForSeconds(waitTime);
        moveSpeed = 5f;
        isHit = false;
    }
}