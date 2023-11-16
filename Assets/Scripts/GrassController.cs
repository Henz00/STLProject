using UnityEngine;

public class GrassController : MonoBehaviour
{
    private bool isTargeted = false;
    public float disappearDelay = 2f;
    public float grassSpawnDelay = 2f;
    public bool isEnabled = true;

    void Start()
    {
        gameObject.SetActive(isEnabled);
        Invoke("GrassSpawnTime", grassSpawnDelay);
    }

    public bool IsTargeted()
    {
        return isTargeted;
    }

    public void SetTargeted(bool value)
    {
        isTargeted = value;
    }

    private void GrassSpawnTime()
    {
        isEnabled = !isEnabled;
        gameObject.SetActive(isEnabled);
    }

    private void DisappearDelayed()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sheep"))
        {
            SheepController sheep = other.GetComponent<SheepController>();
            if (sheep != null)
            {
                sheep.SetIsTargeted(false); // Stop the sheep from targeting grass
                Invoke("DisappearDelayed", disappearDelay);
            }
        }
    }
}