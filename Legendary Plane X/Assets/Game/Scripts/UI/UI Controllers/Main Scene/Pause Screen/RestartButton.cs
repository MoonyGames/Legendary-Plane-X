using UnityEngine;

public class RestartButton : OpenScene
{
    public override void Open(int index)
    {
        Time.timeScale = 1f;

        base.Open(index);
    }
}
