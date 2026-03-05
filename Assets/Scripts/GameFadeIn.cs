using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameFadeIn : MonoBehaviour
{

    public Image fadePanel;
    public float fadeDuration = 1f;


    void Start() 
    {
        StartCoroutine(FadeIn());
    
    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        Color c = fadePanel.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            fadePanel.color = c;
            yield return null;
        }

        c.a = 0f;
        fadePanel.color = c;

        fadePanel.gameObject.SetActive(false);
    }
}
