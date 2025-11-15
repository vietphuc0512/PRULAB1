using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StarBehavior : MonoBehaviour
{
    public float fallSpeed = 2f; 
    public int scoreValue = 1;   
    public TMP_Text scoreText;       

    private Rigidbody2D rb;
    private int currentScore = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Start()
    {
        rb.velocity = Vector2.down * fallSpeed;

        if (scoreText != null)
        {
            int.TryParse(scoreText.text, out currentScore);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GamePlayManager.Instance != null)
                GamePlayManager.Instance.AddScore(scoreValue);

            Destroy(gameObject);
        }
    }
}
