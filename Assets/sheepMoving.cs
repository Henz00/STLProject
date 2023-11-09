using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepMoving : MonoBehaviour
{
    public Transform defaultTarget;
    public Transform alternateTarget;
    public float movementSpeed = 5f;
    public float stoppingDistance = 0.1f;
    public toggleScript enableDisable;
    private Sheep sheepState;

    private void Start()
    {
        sheepState = gameObject.GetComponent<Sheep>();
    }
    void Update()
    {
        if (!sheepState.hasBeenEaten)
        {
            if (enableDisable != null && enableDisable.isEnabled)
            {
                MoveToTarget(alternateTarget);
            }
            else
            {
                MoveToTarget(defaultTarget);
            }
        }
    }

    void MoveToTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        if (direction.magnitude > stoppingDistance)
            transform.Translate(direction.normalized * movementSpeed * Time.deltaTime);
    }
}
