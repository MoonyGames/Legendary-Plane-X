using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    [SerializeField]
    private Material[] skyboxes;

    private void Start()
    {
        RenderSettings.skybox = skyboxes[Random.Range(0, skyboxes.Length)];
    }
}
