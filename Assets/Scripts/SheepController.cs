using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    public string grassTag = "Grass";
    public float moveSpeed = 2f;

    private Transform targetGrass;
    private bool isTargeted = false;

    void Update()
    {
        if (!isTargeted)
        {
            FindNearestAvailableGrass();
        }

        if (targetGrass != null)
        {
            MoveTowardsGrass();
        }
    }

    void FindNearestAvailableGrass()
    {
        GameObject[] grassObjects = GameObject.FindGameObjectsWithTag(grassTag);
        float shortestDistance = Mathf.Infinity;
        Transform nearestGrass = null;

        foreach (GameObject grassObject in grassObjects)
        {
            if (!grassObject.GetComponent<GrassController>().IsTargeted())
            {
                float distanceToGrass = Vector2.Distance(transform.position, grassObject.transform.position);
                if (distanceToGrass < shortestDistance)
                {
                    shortestDistance = distanceToGrass;
                    nearestGrass = grassObject.transform;
                }
            }
        }

        if (nearestGrass != null)
        {
            targetGrass = nearestGrass;
            targetGrass.GetComponent<GrassController>().SetTargeted(true);
        }
    }

    void MoveTowardsGrass()
    {
        Vector2 direction = (targetGrass.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public void SetIsTargeted(bool value)
    {
        isTargeted = value;
    }
}