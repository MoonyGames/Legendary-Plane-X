using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField]
    private Material[] _skins = new Material[4];

    [SerializeField]
    private MeshRenderer _3DViewPlaneMeshRenderer;

    [SerializeField]
    private int[] _skinsCost = new int[4];

    [SerializeField]
    private Button _selectButton;

    [SerializeField]
    private Sprite[] _selectButtonSprites = new Sprite[3];

    [SerializeField]
    private TextMeshProUGUI _selectButtonText, _costText;

    private int index;

    private string prefsSkinMask = "Plane_";

    public delegate void SkinBuy(int count);
    public static event SkinBuy OnSkinBuy;

    private void Awake()
    {
        PlayerPrefs.SetInt("Coins", 1000);
        PlayerPrefs.SetInt("Plane_0", 1);
        index = PlayerPrefs.GetInt("Plane Skin Index", 0);

        _3DViewPlaneMeshRenderer.material = _skins[index];

        UpdateSelectButton();
    }

    public void Change(int plusToIndex)
    {
        if (index + plusToIndex > _skins.Length - 1)
            index = 0;

        else if (index + plusToIndex < 0)
            index = _skins.Length - 1;

        else
            index += plusToIndex;

        _3DViewPlaneMeshRenderer.material = _skins[index];

        UpdateSelectButton();
    }

    private void UpdateSelectButton()
    {
        if(PlayerPrefs.GetInt("Plane Skin Index", 0) == index)
        {
            _selectButton.image.sprite = _selectButtonSprites[2];
            _selectButtonText.text = "Selected";
            _selectButton.interactable = false;

            _costText.gameObject.SetActive(false);

            return;
        }

        if(PlayerPrefs.GetInt(prefsSkinMask + index.ToString(), 0) == 0)
        {
            _selectButton.image.sprite = _selectButtonSprites[0];
            _selectButtonText.text = "Buy";

            _selectButton.onClick.RemoveAllListeners();
            _selectButton.onClick.AddListener(delegate { Buy(); });

            _selectButton.interactable = true;

            _costText.text = _skinsCost[index].ToString();
            _costText.gameObject.SetActive(true);

            if (PlayerPrefs.GetInt("Coins", 0) < _skinsCost[index])
                _selectButton.interactable = false;
        }

        else if (PlayerPrefs.GetInt(prefsSkinMask + index.ToString(), 0) == 1)
        {
            _selectButton.onClick.RemoveAllListeners();
            _selectButton.onClick.AddListener(delegate { Select(); });

            _selectButton.image.sprite = _selectButtonSprites[1];
            _selectButtonText.text = "Select";

            _costText.gameObject.SetActive(false);

            _selectButton.interactable = true;
        }
    }

    public void Select()
    {
        PlayerPrefs.SetInt("Plane Skin Index", index);
        SetSkin.singleton.Set(index);

        UpdateSelectButton();
    }

    public void Buy()
    {
        PlayerPrefs.SetInt("Plane Skin Index", index);
        PlayerPrefs.SetInt(prefsSkinMask + index.ToString(), 1);

        OnSkinBuy?.Invoke(-_skinsCost[index]);

        SetSkin.singleton.Set(index);

        UpdateSelectButton();
    }
}
