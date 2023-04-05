using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMenuController : UIController
{
    [SerializeField] private float _duration = 1f;

    private float timeScale = 0f;

    public void Start()
    {
        for (int i = 0; i < _tweenObjects.Count; i++)
        {
            _tweenObjects[i].Appear(_duration);
        }
    }

    public void OnEnable()
    {
        for (int i = 0; i < _tweenObjects.Count; i++)
        {
            _tweenObjects[i].Appear(_duration);
        }

        timeScale = Time.timeScale;

        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        for (int i = 0; i < _tweenObjects.Count; i++)
        {
            _tweenObjects[i].Disappear(_duration);
        }

        Time.timeScale = timeScale;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
