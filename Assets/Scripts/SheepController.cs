using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    private bool reachedGoal;
    public string grassTag = "Grass";
    public float moveSpeed = 2f;
    public float playerFollowDistance = 5f; // Adjust the distance as needed
    public float playerStopIfClose = 2f;

    private Transform targetGrass;
    private Transform alignToGoal;
    private Transform walkToGoal;

    private bool isTargeted = false;
    private MiniGameManager gameState;
    

    private void Awake()
    {
        gameState = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
        alignToGoal = GameObject.Find("AlignSheepTargetPoint").GetComponent<Transform>();
        walkToGoal = GameObject.Find("SheepTargetPoint").GetComponent<Transform>();

    }

    void Update()
    {
        

        if(reachedGoal)
        {

            WalkToTheGoal(walkToGoal);
        }

        if(!reachedGoal)
        {
            if (!isTargeted)
            {
                FindNearestAvailableGrass();
            }

            if (targetGrass != null)
            {
                MoveTowardsGrass();
            }
            else if (IsPlayerInRange(playerFollowDistance) && !IsPlayerInRange(playerStopIfClose))
            {
                FollowPlayer();
            }

            triggerWalkToGoal(alignToGoal);
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

    void FollowPlayer()
    {
        Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    bool IsPlayerInRange(float range)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        return player != null && Vector2.Distance(transform.position, player.transform.position) <= range;
    }

    public void SetIsTargeted(bool value)
    {
        isTargeted = value;

        if (!isTargeted)
        {
            // Reset targetGrass if no longer targeting
            targetGrass = null;
        }
    }

    void triggerWalkToGoal(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        if (direction.magnitude < 2f)
        {
            reachedGoal = true; 
        }
    }

    void WalkToTheGoal(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        if (direction.magnitude > 0.1f)
            transform.Translate(moveSpeed * Time.deltaTime * direction.normalized);
    }
}