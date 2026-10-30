using UnityEngine;

public class BallMover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Har frame left direction mein move karo
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Agar screen ke bahar chali jaye, toh destroy kar do taaki game slow na ho
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}