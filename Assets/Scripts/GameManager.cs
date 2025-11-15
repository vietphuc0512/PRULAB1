using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int health = 5;
    public TMP_Text scoreText;
    public Text healthText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
        UpdateHealthUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHealthUI();

        if (health <= 0)
        {
            GameOver();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + health;
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("FinalScore", score);
        SceneManager.LoadScene("GameOver");
    }

}
