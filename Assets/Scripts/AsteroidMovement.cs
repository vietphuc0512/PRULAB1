using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AsteroidMovement : MonoBehaviour
{
    public float fallSpeed = 3f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
    }

    void Start()
    {
        rb.velocity = Vector2.down * fallSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
           
            if (GamePlayManager.Instance != null)
            {
                GamePlayManager.Instance.TriggerGameOver();
            }
        }
    }
}
