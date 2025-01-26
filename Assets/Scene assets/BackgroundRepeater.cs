using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] backgrounds; // Array of background GameObjects
    public float speed = 5f; // Speed of background movement
    public float runDuration = 25f; // Duration for how long each background will run (in seconds)

    private int currentBackgroundIndex = 0; // Tracks the current background
    private float timer = 0f; // Timer to track elapsed time
    private bool isRunning = true; // Flag to control background movement

    void Start()
    {
        // Ensure the first background is active
        ActivateBackground(currentBackgroundIndex);
    }

    void Update()
    {
        if (isRunning && currentBackgroundIndex < backgrounds.Length)
        {
            timer += Time.deltaTime;

            // If the time runs out, switch to the next background
            if (timer >= runDuration)
            {
                timer = 0f; // Reset the timer
                SwitchBackground();
            }

            // Move the current background
            MoveBackground();
        }
    }

    void MoveBackground()
    {
        GameObject currentBackground = backgrounds[currentBackgroundIndex];
        Vector2 startPosition = currentBackground.transform.position;
        float width = currentBackground.GetComponent<SpriteRenderer>().bounds.size.x;

        // Move the background
        currentBackground.transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Repeat the background when it reaches the end
        if (currentBackground.transform.position.x <= startPosition.x - width)
        {
            currentBackground.transform.position = new Vector2(startPosition.x, currentBackground.transform.position.y);
        }
    }

    void SwitchBackground()
    {
        // Deactivate the current background
        backgrounds[currentBackgroundIndex].SetActive(false);

        // Move to the next background
        currentBackgroundIndex++;

        if (currentBackgroundIndex < backgrounds.Length)
        {
            // Activate the next background
            ActivateBackground(currentBackgroundIndex);
        }
        else
        {
            isRunning = false; // If no more backgrounds, stop the process
        }
    }

    void ActivateBackground(int index)
    {
        // Activate the background at the specified index
        backgrounds[index].SetActive(true);
    }
}
