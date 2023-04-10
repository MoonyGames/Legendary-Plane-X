using UnityEngine;
using DG.Tweening;

public class CloudMove : FlyingObject
{
    protected override void OnEnable()
    {
        base.OnEnable();

        foreach (Transform child in transform)
        {
            child.GetComponent<MeshRenderer>().material.color = Color.clear;

            child.GetComponent<MeshRenderer>().material.DOColor(new Color(0.8f, 0.8f, 0.8f, 0.2f), 1f);
        }
    }
}
