using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform targetObject;
    public float moveSpeed = 5f;
    public float waitTime = 3f;

    private bool isHit = false;

    void Update()
    {
        if (!isHit)
        {
            MoveTowardsTarget();
        }

        // Check if the enemy is hit by the player (you can replace this with your own condition)
        if (Input.GetButtonDown("AttackButton")) // Change "Fire1" to your input or condition
        {
            StopAllCoroutines(); // Stop any ongoing movement coroutine
            isHit = true;
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
        isHit = false;
    }
}