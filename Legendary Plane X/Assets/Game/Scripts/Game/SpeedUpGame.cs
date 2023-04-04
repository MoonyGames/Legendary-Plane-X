using UnityEngine;

public class SpeedUpGame : MonoBehaviour
{
    [SerializeField]
    private float _amount = 0.01f;

    private static bool IsScaling { get; set; } = true;

    private void Update()
    {
        if (IsScaling)
            Time.timeScale += Time.deltaTime * _amount;
    }

    public static void StopScaling()
    {
        IsScaling = false;

        Time.timeScale = 1f;
    }
}
