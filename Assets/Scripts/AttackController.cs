using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackCooldown = 1.0f;
    private bool isAttacking = false;
    public Animator animator;
    
    public void PerformAttack(GameObject target)
    {
        if (!isAttacking)
        {
            isAttacking = true;
            

            target.GetComponent<EnemyHealth>().TakeDamage(attackDamage);

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
    void Update()
    {
        if (Input.GetButtonDown("AttackButton")) 
        {
            animator.SetTrigger("PerformAttak");
            PerformAttack(gameObject);
            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("PerformAttack");
          
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
