using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{

    [Header("UI")]
    public GameObject pauseButton;      // Gameplay pause button
    public GameObject pauseMenuPanel;   // Full pause menu panel
    public PauseMenuAnimation pauseMenuAnimation;

    public Button resumeButton;
    public Button restartButton;
    public Button mainMenuButton;
    public Button exitButton;


    private bool isPaused = false;

    void Start() 
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;

        resumeButton.onClick.AddListener(ResumeButtonAnimation);
        restartButton.onClick.AddListener(RestartButtonAnimation);
        mainMenuButton.onClick.AddListener(MainMenuButtonAnimation);
        exitButton.onClick.AddListener(ExitButtonAnimation);
    }

    public void PauseGame() 
    {
        if (isPaused)
            return;

        isPaused = true;
        Time.timeScale = 0f;

        pauseMenuPanel.SetActive(true);
        pauseButton.SetActive(false);

        pauseMenuAnimation.PlayAnimation();
    }

    void ResumeButtonAnimation()
    {
        resumeButton.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 10, 1f);
    }

    public void ResumeGame() 
    {
        isPaused = false;
        Time.timeScale = 1f;

        pauseMenuPanel.SetActive(false);
        pauseButton.SetActive(true);
    }


    void RestartButtonAnimation()
    {
        restartButton.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 10, 1f);
    }

    public void RestartGame() 
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void MainMenuButtonAnimation()
    {
        mainMenuButton.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 10, 1f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    void ExitButtonAnimation()
    {
        exitButton.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 10, 1f);
    }

    public void ExitGame() {
        Time.timeScale = 1f;   // safety

        Application.Quit();
        Debug.Log("Game Quit!");
    }
}
