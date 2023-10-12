using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfMove : MonoBehaviour
{
    public Transform targetPoint; // The target point the character should move to.
    public float movementSpeed = 5f; // Adjust the movement speed as needed.

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector3 direction = targetPoint.position - transform.position;
        float distanceToTarget = direction.magnitude;

        if (distanceToTarget > 0.1f) // Adjust this threshold as needed.
        {
            // Move the character towards the target point.
            Vector3 moveDirection = direction.normalized;
            transform.Translate(moveDirection * movementSpeed * Time.deltaTime);
        }
    }

}
