using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField]
    private Sprite _muted, _unmuted;

    private Image image;

    private bool isMute = false;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Mute()
    {
        isMute = !isMute;

        AudioListener.volume = isMute ? 0 : 1;

        image.sprite = isMute ? _muted : _unmuted;
    }
}
