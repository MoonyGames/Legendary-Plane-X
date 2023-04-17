using UnityEngine;
using System.Collections;

public class TutorialAnimationTweening : UIController
{
    [SerializeField]
    private float _duration = 1f;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Tutorial Showed", 0) == 0)
        {
            Time.timeScale = 0f;

            for (int i = 0; i < _tweenObjects.Count; i++)
            {
                _tweenObjects[i].Appear(_duration);
            }

            StartCoroutine(CloseTutorial());

            PlayerPrefs.SetInt("Tutorial Showed", 1);
        }

        else
            Destroy(gameObject);
    }

    private IEnumerator CloseTutorial()
    {
        yield return new WaitForSecondsRealtime(5f);

        Time.timeScale = 1f;

        for (int i = 0; i < _tweenObjects.Count; i++)
        {
            _tweenObjects[i].Disappear(_duration);
        }
    }
}
