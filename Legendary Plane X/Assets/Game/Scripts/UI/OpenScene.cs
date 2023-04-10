using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public void Open(int index)
    {
        SceneManager.LoadScene(index);
    }
}
