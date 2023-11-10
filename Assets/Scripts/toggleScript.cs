using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleScript : MonoBehaviour
{
    public float toggleTime = 2f; // Time in seconds for each toggle
    public bool isEnabled = true; // Initial state
    float time;

    void Start()
    {
        InvokeRepeating("ToggleVisibility", 0f, toggleTime);
    }

    void ToggleVisibility()
    {
        time = Time.time;
        if(Time.deltaTime > time + 5)
        {
            isEnabled = !isEnabled;
            gameObject.SetActive(isEnabled);
        }
        else
        {
            isEnabled = !isEnabled;
            gameObject.SetActive(isEnabled);
        }
    }
}
