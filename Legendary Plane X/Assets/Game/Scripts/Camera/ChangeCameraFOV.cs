using UnityEngine;
using DG.Tweening;

public class ChangeCameraFOV : MonoBehaviour
{
    private Camera camera;

    [SerializeField]
    private float _targetFOV, _duration;

    private float startFOV;

    private void Awake()
    {
        camera = Camera.main;

        startFOV = camera.fieldOfView;

        FlyingBonusCollect.OnBonusCollect += LerpCameraFOV;
    }

    private void LerpCameraFOV()
    {
        camera.DOFieldOfView(_targetFOV, _duration).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            camera.DOFieldOfView(startFOV, 0.5f).SetEase(Ease.InOutSine);
        });
    }

    private void OnDisable()
    {
        FlyingBonusCollect.OnBonusCollect -= LerpCameraFOV;
    }
}
