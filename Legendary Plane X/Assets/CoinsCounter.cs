using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.text = PlayerPrefs.GetInt("Coins", 0).ToString();

        FlyingBonusCollect.OnBonusCollect += AddCoin;
    }

    private void AddCoin()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + 1);

        text.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }
}
