using UnityEngine;
using DG.Tweening;

public class FlyingBombMove : FlyingObject
{
    private Tween rotatingTween;

    protected override void OnEnable()
    {
        rotatingTween = transform.DOLocalRotate(new Vector3(0f, 0f, 30f), 1f).SetEase(Ease.InOutSine).SetLoops(20, LoopType.Yoyo);

        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void OnDisable()
    {
        rotatingTween.Complete();
    }
}
