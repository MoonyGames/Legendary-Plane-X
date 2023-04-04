using UnityEngine;
using MilkShake;

public class ShakeCamera : MonoBehaviour
{
    public static ShakeCamera singleton { get; private set; }

    [SerializeField]
    private Shaker _shaker;

    [SerializeField]
    private ShakePreset _shakePreset;

    private void Awake()
    {
        singleton = this;
    }

    public void Shake()
    {
        _shaker.Shake(_shakePreset);
    }
}
