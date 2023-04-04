using UnityEngine;
using System.Collections;

public class FlyingBombGenerator : ObjectPooler
{
    [SerializeField]
    private Vector2 _minPosition, _maxPosition;

    protected override IEnumerator GenerateLooped(float timeBetweenIterations)
    {
        while (IsGenerating)
        {
            GameObject bomb = GetPooledObject();

            if (bomb != null)
            {
                bomb.transform.position = new Vector3(0f, Random.Range(_minPosition.x, _maxPosition.x),Random.Range(_minPosition.y, _maxPosition.y));

                bomb.SetActive(true);
            }

            StartCoroutine(DestroyOnTimer(bomb, _timeToDestroy));

            float time = Random.Range(1f, timeBetweenIterations + 3f);

            yield return new WaitForSeconds(time);
        }
    }
}
