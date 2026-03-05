using UnityEngine;
using DG.Tweening;

public class MenuEntryAnimation : MonoBehaviour
{
    public RectTransform[] buttons;
    public float delayBetweenButtons = 0.12f;


    void OnEnable()
    {
        PlayMenuAnimation();
    }

    void PlayMenuAnimation()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            RectTransform button = buttons[i];
            button.localScale = Vector3.zero;

            button.DOScale(1f, 0.25f)
                .SetDelay(i * delayBetweenButtons)
                .SetEase(Ease.OutBack)
                .SetUpdate(true);
        }
    }
}
