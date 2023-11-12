using UnityEngine;

public class GrassController : MonoBehaviour
{
    private bool isTargeted = false;

    public bool IsTargeted()
    {
        return isTargeted;
    }

    public void SetTargeted(bool value)
    {
        isTargeted = value;
    }
}