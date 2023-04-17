using UnityEngine;

public class SetScreenOrientation : MonoBehaviour
{
    [SerializeField]
    private ScreenOrientation _screenOrientation;

    private void Start()
    {
        Screen.orientation = _screenOrientation;
    }
}
