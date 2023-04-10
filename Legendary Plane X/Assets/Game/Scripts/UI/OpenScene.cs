using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public virtual void Open(int index)
    {
        SceneManager.LoadScene(index);
    }
}
