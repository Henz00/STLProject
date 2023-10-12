using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHerderGameManager : MonoBehaviour
{
    private Sheep SheepCondition;
    private TimeManager timer;

    void Start()
    {
        SheepCondition = GameObject.Find("Sheep").GetComponent<Sheep>();
        timer = gameObject.GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SheepCondition.hasBeenEaten == true)
        {
            
        }
    }
}
