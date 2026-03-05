using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameOverPanelAnimation gameOverPanelAnimation;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    bool isGameOver = false;


    void Start() 
    {
        gameOverPanel.SetActive(false);           // Panel off by default
    }

    public void GameOver(int score) 
    {
        if (isGameOver)
            return;
        isGameOver = true;

        Time.timeScale = 0f;

        gameOverPanel.SetActive(true);                  // Show Panel

        gameOverPanelAnimation.PlayGameOverAnimation();  // Play Animation

        finalScoreText.text = "SCORE: " + score;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "HIGHSCORE: " + highScore;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
