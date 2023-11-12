using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    void DisableEntities()
    {
        foreach (Transform g in transform.GetComponentsInChildren<Transform>())
            g.parent.parent.gameObject.SetActive(false);
    }
}
