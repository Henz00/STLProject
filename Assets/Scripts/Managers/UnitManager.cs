using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    void DisableEntities()
    {
        foreach (Transform g in gameObject.GetComponentsInChildren<Transform>())
            g.parent.parent.gameObject.SetActive(false);
    }
}
