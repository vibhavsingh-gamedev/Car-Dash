using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public Transform player;   // Car
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    // private float startZ;
    public Player _player;
    private float score = 0f;
    public float scoreSpeed = 5f;     // You can tune this value



    void Start() {
       // startZ = player.position.z;
        //score = 0;

        scoreText.gameObject.SetActive(false);  // Start mein hide rahega score

        UpdateHighScoreUI();
        UpdateScoreUI();
    }

    private void Update()
    {

        if (Time.timeScale == 0f)     // paused-->> No Score
            return;

        if(!_player.canMove)
            return;

        score += scoreSpeed * Time.deltaTime;  // speed control

        // scoreText.text = Mathf.FloorToInt(score).ToString();

        UpdateScoreUI();
    }


    void UpdateScoreUI()
    {
        scoreText.text = Mathf.FloorToInt(score).ToString();

        // int highScore = PlayerPrefs.GetInt("HighScore", 0);
        // highScoreText.text = "HIGHSCORE " + highScore;
    }


    void UpdateHighScoreUI()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "HIGHSCORE " + highScore;
    }

    public void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", Mathf.FloorToInt(score));
            PlayerPrefs.Save();
        }
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }


    public void ShowScore() 
    {
        scoreText.gameObject.SetActive(true);

        RectTransform rt = scoreText.rectTransform;

        // Initial state (upar + thoda chota)
        rt.localScale = Vector3.one * 0.85f;

        Vector2 startPos = rt.anchoredPosition;
        rt.anchoredPosition = startPos + new Vector2(0, 120f);  // upar se start

        // Position drop (smooth)
        rt.DOAnchorPos(startPos, 0.9f)
            .SetEase(Ease.OutExpo);

        // Scale pop (soft & readable)
        rt.DOScale(1f, 0.9f)
            .SetEase(Ease.OutBack, 0.8f);

        //scoreText.transform.localScale = Vector3.zero;
        //scoreText.transform
        //    .DOScale(1f, 0.35f)
        //    .SetEase(Ease.OutBack);
    }

    public void HideScore()
    {
        scoreText.gameObject.SetActive(false);
    }
}
