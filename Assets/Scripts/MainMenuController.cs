using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject instructionsPanel;

    void Start()
    {
        Debug.Log("MainMenuController is running");
        instructionsPanel.SetActive(false); 
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}
