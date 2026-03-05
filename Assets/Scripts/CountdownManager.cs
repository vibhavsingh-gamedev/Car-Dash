using DG.Tweening;
using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public Player player; // Reference to the Player script
    public Camera mainCamera;
    public ScoreManager scoreManager; // Reference to the scoreManager script

    public ParticleSystem dustParticle;

    private void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        scoreManager.HideScore();   /// Hide score during countdown

        countdownText.gameObject.SetActive(true);

        countdownText.color = Color.white; // reset color

        countdownText.text = "3";
        AnimateCountdown();
        yield return new 
            WaitForSeconds(1f);

        countdownText.text = "2";
        AnimateCountdown();
        yield return new 
            WaitForSeconds(1f);

        countdownText.text = "1";
        AnimateCountdown();
        yield return new 
            WaitForSeconds(1f);

        countdownText.text = "GO!";
        countdownText.color = new Color(0.2f, 0.9f, 0.3f);

        dustParticle.Emit(15); // Emit dust particles

        // GO Pop
        countdownText.transform.localScale = Vector3.one * 0.7f;
        countdownText.transform
            .DOScale(1.4f, 0.35f)
            .SetEase(Ease.OutBack);

        countdownText.transform.DOLocalMoveY(20f, 0.35f)
            .SetEase(Ease.OutSine);

        yield return new 
            WaitForSeconds(0.5f);

        player.canMove = true; // Enable player movement

        scoreManager.ShowScore(); // Show score after countdown

        countdownText.gameObject.SetActive(false);
    }

    void AnimateCountdown() 
    {
        RectTransform rt = countdownText.rectTransform;
        rt.DOKill();

        // Perfect Center Base
        Vector2 basePos = rt.anchoredPosition;

        // Start slightly above Center (not below)
        rt.localScale = Vector3.one * 0.6f;
        rt.anchoredPosition = basePos + new Vector2(0f, 10f);

        // Smooth Float to Exact Center
        rt.DOAnchorPos(basePos, 0.45f)
            .SetEase(Ease.OutSine);

        // Pop scale
        rt.DOScale(1.2f, 0.25f)
            .SetEase(Ease.OutBack)
            .OnComplete(() => 
            {
                rt.DOScale(1f, 0.2f);
            });

    }
}
