using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMove : MonoBehaviour
{
    public Transform targetPoint; // The target point the sheep should move to.
    public float movementSpeed = 1f; // Adjust the movement speed as needed.
    private Sheep sheepState;

    private void Start()
    {
        targetPoint = GameObject.Find("SheepTargetPoint").GetComponent<Transform>();
        sheepState = gameObject.GetComponent<Sheep>();
    }

    private void Update()
    {
        if (!sheepState.hasBeenEaten)
        {
            MoveToTarget();
        }
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
