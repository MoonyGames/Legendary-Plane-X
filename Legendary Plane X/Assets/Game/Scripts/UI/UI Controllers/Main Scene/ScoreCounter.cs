using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;

    [SerializeField]
    private float _timeBetweenScores;

    private float counter = 0;

    private bool isCount = false;

    private Coroutine counterCoroutine;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();

        FlyingBombKill.OnBombKill += StopCounter;
    }

    private void Start()
    {
        StartCounter();
    }

    private IEnumerator Counter()
    {
        while (isCount)
        {
            yield return new WaitForSeconds(_timeBetweenScores);

            textMeshProUGUI.text = (++counter).ToString();
        }
    }

    private void StartCounter()
    {
        isCount = true;

        counterCoroutine = StartCoroutine(Counter());
    }

    private void StopCounter()
    {
        isCount = false;

        StopCoroutine(counterCoroutine);
    }

    private void OnDisable()
    {
        FlyingBombKill.OnBombKill -= StopCounter;
    }
}
