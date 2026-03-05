using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Image loadingBarFill;
    public float smoothSpeed = 0.5f;

    public Image fadePanel;
    public float fadeDuration = 0.8f;

    float targetFill = 0f;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    void Update()
    {
        // Smooth movement
        loadingBarFill.fillAmount = Mathf.Lerp(
            loadingBarFill.fillAmount,
            targetFill,
            Time.deltaTime * smoothSpeed
        );
    }

    IEnumerator LoadSceneAsync()
    {
        float minLoadTime = 4.5f;  // minimum loading screen time
        float timer = 0f;

        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            timer += Time.deltaTime;

            // Unity loads till 0.9 internally
            float loadProgress = Mathf.Clamp01(operation.progress / 0.9f);

            // Fake smooth progress based on time
            float timeProgress = Mathf.Clamp01(timer / minLoadTime);

            // Pick the slower one (for smooth feel)
            targetFill = Mathf.Min(loadProgress, timeProgress);

            // Allow scene only when BOTH done
            if (loadProgress >= 0.99f && timer >= minLoadTime) 
            {
                //yield return new WaitForSeconds(0.3f); // small delay for better UX

                yield return StartCoroutine(FadeOut());  // Fade Here

                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    IEnumerator FadeOut() 
    {
        float t = 0f;
        Color c = fadePanel.color;

        while (t < fadeDuration) 
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            fadePanel.color = c;
            yield return null;
        }

        c.a = 1f;
        fadePanel.color = c;
    }
}

