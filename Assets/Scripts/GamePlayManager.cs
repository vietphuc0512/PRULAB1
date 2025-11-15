using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Instance;

    [Header("Gameplay Stats")]
    public int score = 0;


    [Header("UI Elements")]
    public TMP_Text scoreText;
   

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

    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }


    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    

    public void TriggerGameOver()
    {
        PlayerPrefs.SetInt("FinalScore", score);
        SceneManager.LoadScene("GameOver");
    }
}
