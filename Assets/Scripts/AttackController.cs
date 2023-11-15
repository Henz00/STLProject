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
        enemy.GetComponent<EnemyMovement>().enabled = false;
        enemy.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 100, ForceMode2D.Force);
        StartCoroutine(StunTimer());
    }

    bool IsEnemyClose(Transform enemy)
    {
        bool isClose;

        if (Vector3.Distance(enemy.position, gameObject.transform.position) < 40f)
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
    private IEnumerator StunTimer()
    {
        yield return new WaitForSeconds(StunTime);
        enemy.GetComponent<EnemyMovement>().enabled = true;
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        StunController stunController = GetComponent<StunController>();
    //        stunController.StunObject(other.gameObject);

    //    }
    //}
}
