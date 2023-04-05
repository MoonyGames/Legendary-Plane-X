using UnityEngine;

public class ActivateGameObjectButton : MonoBehaviour
{
    public void ActivateGameObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
