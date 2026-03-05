using UnityEngine;
using DG.Tweening;

public class PauseMenuAnimation : MonoBehaviour
{
    [Header("UI References")]
    public RectTransform pausedText;
    public RectTransform resumeButton;
    public RectTransform restartButton;
    public RectTransform mainMenuButton;
    public RectTransform exitButton;


    public void PlayAnimation()
    {
        ResetUI();

        // Paused Text 
        pausedText.DOScale(1f, 0.25f)
            .SetEase(Ease.OutCubic)
            .SetUpdate(true);

        // BUTTONS
        // Resume Button 
        resumeButton.DOScale(1f, 0.22f)
            .SetDelay(0.25f)
            .SetEase(Ease.OutBack, 0.8f)
            .SetUpdate(true);

        // Restart Button 
        restartButton.DOScale(1f, 0.22f)
            .SetDelay(0.35f)
            .SetEase(Ease.OutBack, 0.8f)
            .SetUpdate(true);

        // MainMenu Button 
        mainMenuButton.DOScale(1f, 0.22f)
            .SetDelay(0.45f)
            .SetEase(Ease.OutBack, 0.8f)
            .SetUpdate(true);

        // Exit Button - slightly delayed
        exitButton.DOScale(1f, 0.22f)
            .SetDelay(0.55f)
            .SetEase(Ease.OutBack, 0.8f)
            .SetUpdate(true);
    }

    void ResetUI()
    {
        // Kill any previous tweens (for safety)
        DOTween.Kill(pausedText);
        DOTween.Kill(resumeButton);
        DOTween.Kill(restartButton);
        DOTween.Kill(mainMenuButton);
        DOTween.Kill(exitButton);

        pausedText.localScale = Vector3.zero;
        resumeButton.localScale = Vector3.zero;
        restartButton.localScale = Vector3.zero;
        mainMenuButton.localScale = Vector3.zero;
        exitButton.localScale = Vector3.zero;
    }
}




