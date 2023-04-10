using UnityEngine;
using TMPro;

public class ShowScores : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    [SerializeField]
    private TextMeshProUGUI _scoresText;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        textMeshProUGUI.text = _scoresText.text;
    }
}
