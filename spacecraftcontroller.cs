using UnityEngine;

public class SpacecraftController : MonoBehaviour
{
    public float speed = 10f;  // Movement speed

    void Update()
    {
        // Move the spacecraft up or down
        float moveUpDown = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Move the spacecraft along the y-axis (up/down)
        transform.Translate(0, moveUpDown, 0);
    }
}

