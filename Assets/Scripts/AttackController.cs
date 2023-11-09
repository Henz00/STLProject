using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackCooldown = 3.0f;
    private bool isAttacking = false;
    public Animator animator;
    

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


            //target.GetComponent<EnemyHealth>().TakeDamage(attackDamage);

            StartCoroutine(AttackCooldown());

            void OnTriggerEnter(Collider other)
            {
                if (other.CompareTag("Enemy"))
                {
                    StunController stunController = GetComponent<StunController>();
                    stunController.StunObject(other.gameObject);
                }
            }
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
