using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    MiniGameManager miniGameManager;
    public int attackDamage = 10;
    float stunTime = 2.5f;
    public Animator animator;
    public AudioSource swing;
    public AudioSource hitBush;
    private GameObject[] grassObjects;
    private GameObject enemy;

    void Awake()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
        enemy = GameObject.Find("Wolf");
        grassObjects = GameObject.FindGameObjectsWithTag("Grass");
        swing = GetComponent<AudioSource>();
        hitBush = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("AttackButton"))
        {
            if (enemy != null && IsEnemyClose(enemy.transform))
            {
                Attack(enemy);
            }
            else if (IsGrassClose(out GameObject closestGrass))
            {
                DisableGrass(closestGrass);
            }
        }
    }

    void DisableGrass(GameObject grass)
    {
        if (grass != null)
        {
            grass.SetActive(false);
            animator.SetTrigger("PerformAttack");
            hitBush.Play();
        }
    }

    bool IsGrassClose(out GameObject closestGrass)
    {
        closestGrass = FindClosestGrass();
        return closestGrass != null && Vector2.Distance(transform.position, closestGrass.transform.position) < 4f;
    }

    GameObject FindClosestGrass()
    {
        GameObject closestGrass = null;
        float closestDistance = float.MaxValue;

        foreach (var grassObject in grassObjects)
        {
            float distanceToGrass = Vector2.Distance(transform.position, grassObject.transform.position);
            if (distanceToGrass < closestDistance)
            {
                closestDistance = distanceToGrass;
                closestGrass = grassObject;
            }
        }

        return closestGrass;
    }

    void Attack(GameObject enemy)
    {
        Vector2 direction = enemy.transform.position - transform.position;
        animator.SetTrigger("PerformAttack");
        miniGameManager.EnemyHit(this, EventArgs.Empty);
        enemy.GetComponent<EnemyMovement>().enabled = false;
        enemy.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 5, ForceMode2D.Impulse);
        swing.Play();
        StartCoroutine(StunTimer(stunTime));
        enemy.GetComponent<EnemyMovement>().enabled = true;
    }

    bool IsEnemyClose(Transform enemy)
    {
        return Vector3.Distance(enemy.position, transform.position) < 4f;
    }

    IEnumerator StunTimer(float stuntime)
    {
        yield return new WaitForSeconds(stuntime);
        GetComponent<PlayerMovement>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") && !collision.collider.GetComponent<Wolf>().isStunned)
        {
            GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine(StunTimer(2f));
        }
    }
}
