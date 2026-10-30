using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Smoothly follow mouse/touch position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = Vector3.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);

        // Clamp player position so they stay inside the camera view
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, 0.05f, 0.95f); // Left and right bounds
        viewPos.y = Mathf.Clamp(viewPos.y, 0.05f, 0.95f); // Bottom and top bounds
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RedBall"))
        {
            if (GameManager.Instance != null && GameManager.Instance.isInvulnerable)
            {
                return; // Safe from red ball during power-up
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.TriggerGameOver();
            }
        }
        else if (collision.CompareTag("BlueBall"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.TriggerBlueBallPowerUp();
            }
            Destroy(collision.gameObject);
        }
    }
}