using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateClosChecker : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sheep"))
        {   
            targetSpriteRenderer.enabled = true;
        }
    }
}
