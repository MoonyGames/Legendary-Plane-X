using System;
using UnityEngine;
using TMPro;

public class DailyBonusScreenController : UIController
{
    [SerializeField]
    private float _duration = 1f;

    [SerializeField]
    private int _rewardSize = 25;

    [SerializeField]
    private float _screenDuration = 5f;

    [SerializeField]
    private TextMeshProUGUI _text;

    private DateTime currentDate;
    private DateTime oldDate;

    private void Start()
    {
        currentDate = DateTime.Now;

        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString", DateTime.Now.AddDays(-1).ToBinary().ToString()));
        oldDate = DateTime.FromBinary(temp);

        TimeSpan difference = currentDate.Subtract(oldDate);

        PlayerPrefs.SetString("sysString", DateTime.Now.ToBinary().ToString());

        if (difference.Days == 1)
        {
            GetReward();

            for (int i = 0; i < _tweenObjects.Count; i++)
                _tweenObjects[i].Appear(_duration);

            Invoke("CloseScreen", _screenDuration);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void CloseScreen()
    {
        for (int i = 0; i < _tweenObjects.Count; i++)
            _tweenObjects[i].Disappear(_duration);
    }

    private void GetReward()
    {
        _text.text = _rewardSize.ToString();

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + _rewardSize);
    }
}
