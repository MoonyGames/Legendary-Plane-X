using UnityEngine;

public class SetScreenOrientation : MonoBehaviour
{
    [SerializeField]
    private ScreenOrientation _screenOrientation;

    private ScreenOrientation ScreenOrientation
    {
        get { return _screenOrientation; }

        set
        {
            _screenOrientation = value;

            Start();
        }
    }

    private void Start()
    {
        Screen.orientation = _screenOrientation;
    }
}
