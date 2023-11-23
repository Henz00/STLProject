using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    MiniGameManager miniGameManager;
    public int attackDamage = 10;
    float StunTime = 2.5f;
    public Animator animator;
    public AudioSource swing;


    GameObject enemy;

    void Awake()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
        enemy = GameObject.Find("Wolf");
        
    }
    void Update()
    {
        if (Input.GetButtonDown("AttackButton") && IsEnemyClose(enemy.transform)) 
            Attack(enemy);
    }

    void Attack(GameObject enemy)
    {
        Vector2 direction = enemy.transform.position - gameObject.transform.position;
        animator.SetTrigger("PerformAttack");
        miniGameManager.EnemyHit(this, EventArgs.Empty);
        enemy.GetComponent<EnemyMovement>().enabled = false;
        enemy.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 2, ForceMode2D.Impulse);
        swing.Play();
        StartCoroutine(StunTimer(StunTime));
        enemy.GetComponent<EnemyMovement>().enabled = true;
    }

    bool IsEnemyClose(Transform enemy)
    {
        bool isClose;

        if (Vector3.Distance(enemy.position, gameObject.transform.position) < 4f)
            isClose = true;
        else
            isClose = false;

        return isClose;
    }
    //void Attack()
    //{
    //    animator.SetTrigger("PerformAttack");
    //    if (!isAttacking)
    //    {
    //        isAttacking = true;
    //        HitEnemy?.Invoke(this, EventArgs.Empty);

    //        //target.GetComponent<EnemyHealth>().TakeDamage(attackDamage);

    //        StartCoroutine(AttackCooldown());
    //    }

    //}
    private IEnumerator StunTimer(float stuntime)
    {
        yield return new WaitForSeconds(stuntime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") && !collision.collider.GetComponent<Wolf>().isStunned)
        {
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            StunTimer(2f);
            gameObject.GetComponent<PlayerMovement>().enabled = false;

        }

    }
}
