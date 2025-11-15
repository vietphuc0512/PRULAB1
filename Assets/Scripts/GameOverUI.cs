using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text finalScoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + finalScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
