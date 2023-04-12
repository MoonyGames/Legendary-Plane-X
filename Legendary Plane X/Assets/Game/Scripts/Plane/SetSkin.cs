using UnityEngine;

public class SetSkin : MonoBehaviour
{
    public static SetSkin singleton { get; private set; }

    [SerializeField]
    private Material[] _skins = new Material[4];

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        singleton = this;

        meshRenderer = GetComponent<MeshRenderer>();

        Set(PlayerPrefs.GetInt("Plane Skin Index", 0));
    }

    public void Set(int index)
    {
        meshRenderer.material = _skins[index];
    }
}
