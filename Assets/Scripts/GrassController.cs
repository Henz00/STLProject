using UnityEngine;

public class GrassController : MonoBehaviour
{
    private bool isTargeted = false;
    public float disappearDelay = 2f;
    public float grassSpawnDelay = 2f;
    public bool isEnabled = true;

    // Adjust these values to set the range for grass spawn
    public float minX = -10f;
    public float maxX = 6f;
    public float minY = -2f;
    public float maxY = 2f;

    private Vector2 initialPosition;

    void Start()
    {
        gameObject.SetActive(isEnabled);
        initialPosition = transform.position; // Save the initial position
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
        // Randomly set the offset within the specified range
        float offsetX = Random.Range(minX, maxX);
        float offsetY = Random.Range(minY, maxY);

        // Calculate the new position based on the initial position
        Vector2 newPosition = new Vector2(initialPosition.x + offsetX, initialPosition.y + offsetY);

        transform.position = newPosition;

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