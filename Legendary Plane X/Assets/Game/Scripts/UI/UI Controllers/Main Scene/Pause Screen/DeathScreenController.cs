using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DeathScreenController : UIController
{
    [SerializeField]
    private float _duration = 1f;

    [SerializeField]
    private Button _pauseButton;

    public void Start()
    {
        _pauseButton.interactable = false;

        for (int i = 0; i < _tweenObjects.Count; i++)
        {
            _tweenObjects[i].Appear(_duration);
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
