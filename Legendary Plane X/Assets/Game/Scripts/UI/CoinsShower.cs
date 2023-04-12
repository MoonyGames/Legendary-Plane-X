using UnityEngine;
using TMPro;

public class CoinsShower : MonoBehaviour
{
    protected TextMeshProUGUI text;

    protected virtual void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }

    protected virtual void AddCoin(int count)
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + count);

        text.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }
}
