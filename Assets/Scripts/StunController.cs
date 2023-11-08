using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunController : MonoBehaviour
{
    public float stunDuration = 2.0f;
    private bool isStunned = false;

    public void StunObject(GameObject target)
    {
        if (!isStunned)
        {
            isStunned = true;
            //target.GetComponent<StunEffectScript>().PlayStunEffect();

            StartCoroutine(UnstunAfterDelay(target));
        }
    }

    private IEnumerator UnstunAfterDelay(GameObject target)
    {
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
    }
}
