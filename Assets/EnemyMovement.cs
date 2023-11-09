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

        if (Input.GetButtonDown("AttackButton")) 
        {
            StopAllCoroutines(); 
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