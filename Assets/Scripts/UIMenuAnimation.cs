using UnityEngine;
using DG.Tweening;
using UnityEditor.PackageManager.Requests;

public class UIMenuAnimation : MonoBehaviour
{
    [Header("Optional Title")]
    public RectTransform titleText;

    [Header("Menu Buttons (order matters)")]
    public RectTransform[] buttons;

    [Header("Animation Settings")]
    public float startDelay = 0f;
    public float buttonGap = 0.15f;


    public void Play() 
    {
        ResetUI();

        float delay = startDelay;

        // Title animation
        if (titleText != null) 
        {
            titleText.DOScale(1.15f, 0.35f)
                .SetEase(Ease.OutBack)
                .SetUpdate(true)
                .OnComplete(() => titleText.DOScale(1f, 0.15f).SetUpdate(true));

            delay += 0.4f;
        }

        // Buttons animation

        foreach (RectTransform button in buttons)
        {
            button.DOScale(1.1f, 0.25f)
                .SetDelay(delay)
                .SetEase (Ease.OutBack)
                .SetUpdate(true)
                .OnComplete(() => button.DOScale(1f, 0.12f).SetUpdate(true));

            delay += buttonGap;
        }
    }

    void ResetUI()
    {
        if (titleText != null)
            titleText.localScale = Vector3.zero;

        foreach (RectTransform button in buttons)
        {
            button.localScale = Vector3.zero;
        }
    }
}
