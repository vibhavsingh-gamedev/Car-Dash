using System.Collections;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    
    public float startScale = 0.75f;
    public float endScale = 1.05f;
    public float duration = 0.35f;

    void Start() 
    {
        StartCoroutine(ScalePop());
    }

    IEnumerator ScalePop() 
    {
        float time = 0f;
        transform.localScale = Vector3.one * startScale;

        while (time < duration) 
        {
            time += Time.deltaTime;
            float t = time / duration;

            // Ease out (Smooth finish)
            //t = Mathf.SmoothStep(0f, 1f, t);

            // Stronger EaseOut
            t = 1 - Mathf.Pow(1 - t, 3);

            float scale = Mathf.Lerp(startScale, endScale, t);
            transform.localScale = Vector3.one * scale;

            yield return null;
        }

        // transform.localScale = Vector3.one * endScale;
        transform.localScale = Vector3.one * 1.05f;
        yield return new WaitForSecondsRealtime(0.05f);
        transform.localScale = Vector3.one;

    }
}
