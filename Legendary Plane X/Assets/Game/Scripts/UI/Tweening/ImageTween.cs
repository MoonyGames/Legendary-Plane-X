using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ImageTween : MonoBehaviour, ITweanable
{
    [SerializeField] private UIController _UIController;

    private Image _image;
    private RectTransform _rectTransform;

    private float _startPosY;

    [SerializeField] private bool _scaleable = true;

    [SerializeField] private float _finalAlpha = 1f;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();

        _startPosY = _rectTransform.anchoredPosition.y;

        _UIController.AddTweenObjects(this);
    }

    public void Appear(float duration)
    {
        Color tempColor = _image.color;
        tempColor.a = 0f;

        _image.color = tempColor;

        if (_scaleable)
        {
            _rectTransform.localScale = Vector3.zero;

            _rectTransform.DOScale(Vector3.one, duration).SetUpdate(true);
        }

        _image.DOFade(_finalAlpha, duration).SetUpdate(true);
    }

    public void Disappear(float duration)
    {
        _rectTransform.DOScale(Vector3.zero, duration).SetUpdate(true);

        _image.DOFade(0f, duration).SetUpdate(true).OnComplete(() =>
        {
            _UIController.gameObject.SetActive(false);
        });
    }
}
