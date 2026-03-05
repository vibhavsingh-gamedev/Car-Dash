using DG.Tweening;
using System.Collections;
using UnityEngine;

public class GameOverPanelAnimation : MonoBehaviour
{
    [Header("UI References")]
    public RectTransform gameOverText;
    public CanvasGroup finalScoreText;
    public CanvasGroup highScoreText;

    public RectTransform restartButton;
    public RectTransform quitButton;


    public void PlayGameOverAnimation()
    {
        ResetUI();

        // GameOver Text Pop - clean pop (no heavy bounce)
        gameOverText.DOScale(1f, 0.25f)
            .SetEase(Ease.OutCubic)
            .SetUpdate(true);

        // Score FadeIn
        finalScoreText.DOFade(1f, 0.25f)
            .SetDelay(0.30f)
            .SetUpdate(true);

        highScoreText.DOFade(1f, 0.25f)
            .SetDelay(0.40f)
            .SetUpdate(true);

        // Restart Button - soft pop
        restartButton.DOScale(1f, 0.22f)
            .SetDelay(0.55f)
            .SetEase(Ease.OutBack, 0.8f)
            .SetUpdate(true);

        // Quit Button - slightly delayed
        quitButton.DOScale(1f, 0.22f)
            .SetDelay(0.65f)
            .SetEase(Ease.OutBack, 0.75f)
            .SetUpdate(true);
    }
    void ResetUI()
    {
        // Kill any previous tweens (for safety)
        DOTween.Kill(gameOverText);
        DOTween.Kill(finalScoreText);
        DOTween.Kill(highScoreText);
        DOTween.Kill(restartButton);
        DOTween.Kill(quitButton);

        gameOverText.localScale = Vector3.one * 0.01f;

        finalScoreText.alpha = 0f;
        highScoreText.alpha = 0f;

        restartButton.localScale = Vector3.one * 0.01f;
        quitButton.localScale = Vector3.one * 0.01f;
    }
}
