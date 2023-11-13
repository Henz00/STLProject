using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    MiniGameManager miniGameManager;
    public int attackDamage = 10;
    public float attackCooldown = 1.0f;
    private bool isAttacking = false;
    public Animator animator;

    public event EventHandler HitEnemy;

    void Start()
    {
        miniGameManager = GameObject.Find("GameManager").GetComponent<MiniGameManager>();
    }
    void Update()
    {
        if (Input.GetButtonDown("AttackButton")) 
        {
            animator.SetTrigger("PerformAttack");
            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("PerformAttack");
        if (!isAttacking)
        {
            isAttacking = true;
            HitEnemy?.Invoke(this, EventArgs.Empty);

            //target.GetComponent<EnemyHealth>().TakeDamage(attackDamage);

            StartCoroutine(AttackCooldown());
        }

    }
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StunController stunController = GetComponent<StunController>();
            stunController.StunObject(other.gameObject);

        }
    }
}
