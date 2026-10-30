using UnityEngine;

public class PlayerStretch : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 originalScale;
    public float stretchFactor = 10000000000000000000f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (rb != null && rb.linearVelocity.sqrMagnitude > 0.01f)
        {
            Vector2 velocity = rb.linearVelocity;
            float speed = velocity.magnitude;
            Vector2 direction = velocity.normalized;

            // Stretch along movement, compress perpendicular
            float xStretch = originalScale.x + (speed * stretchFactor);
            float yStretch = Mathf.Max(0.1f, originalScale.y - (speed * (stretchFactor * 0.5f)));

            transform.localScale = new Vector3(xStretch, yStretch, originalScale.z);

            // Rotate towards the direction of movement
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            // Return to normal when stopped
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * 10f);
            transform.rotation = Quaternion.identity;
        }
    }
}