using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Laser : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Start()
    {
        rb.velocity = Vector2.up * speed; 
    }

    void Update()
    {
        if (transform.position.y > 6f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
