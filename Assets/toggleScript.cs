using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleScript : MonoBehaviour
{
    public float toggleTime = 2f; // Time in seconds for each toggle
    public bool isEnabled = true; // Initial state

    void Start()
    {
        InvokeRepeating("ToggleVisibility", 0f, toggleTime);
    }

    void ToggleVisibility()
    {
        isEnabled = !isEnabled;
        gameObject.SetActive(isEnabled);
    }
}
