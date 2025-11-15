using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject laserPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float nextFire = 0f;
    public AudioClip attackClip;
    private AudioSource audioSource;


    public void FireLaser()
    {
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        if (audioSource != null && attackClip != null)
            audioSource.PlayOneShot(attackClip);
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.freezeRotation = true;
    }

    void Update()
    {
        // --- Input ---
        movement = Vector2.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            movement += Vector2.up;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            movement += Vector2.down;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            movement += Vector2.left;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            movement += Vector2.right;

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }
}
