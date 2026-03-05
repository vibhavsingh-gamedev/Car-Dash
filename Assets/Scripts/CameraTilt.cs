using UnityEngine;
using DG.Tweening;


public class CameraTilt : MonoBehaviour
{
    public float tiltAngle = 6f;
    public float tiltTime = 0.2f;

    private Tween tiltTween;

    public void TiltLeft()
    {
        TiltTo(tiltAngle);
    }

    public void TiltRight()
    {
        TiltTo(-tiltAngle);
    }

    public void ResetTilt()
    {
        TiltTo(0f);
    }

    void TiltTo(float z)
    {
        tiltTween?.Kill();
        tiltTween = transform.DOLocalRotate(
            new Vector3(0, 0, z),
            tiltTime
        ).SetEase(Ease.OutCubic);
    }
}


