using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunController : MonoBehaviour
{
    public float stunDuration = 2.0f;
    private bool isStunned = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StunController stunController = GetComponent<StunController>();
            stunController.StunObject(other.gameObject);

        }
    }
    public void StunObject(GameObject target)
    {
        if (!isStunned)
        {
            isStunned = true;
            // afspil stuneffect når asset findes (particles, sound)
            // target.GetComponent<StunEffectScript>().PlayStunEffect();

            StartCoroutine(UnstunAfterDelay(target));
        }
    }

    private IEnumerator UnstunAfterDelay(GameObject target)
    {
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
    }
}
