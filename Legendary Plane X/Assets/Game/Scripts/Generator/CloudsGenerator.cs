using UnityEngine;
using System.Collections;

public class CloudsGenerator : ObjectPooler
{
    [SerializeField]
    private Vector3 _minPosition, _maxPosition;

    protected override IEnumerator GenerateLooped(float timeBetweenIterations)
    {
        while (IsGenerating)
        {
            GameObject cloud = GetPooledObject();

            if (cloud != null)
            {
                cloud.transform.position = new Vector3(Random.Range(_minPosition.x, _maxPosition.x), Random.Range(_minPosition.y, _maxPosition.y), Random.Range(_minPosition.z, _maxPosition.z));
                cloud.transform.rotation = Quaternion.Euler(Random.Range(-30f, 30f), Random.Range(0f, 360f), Random.Range(-30f, 30f));

                cloud.SetActive(true);
            }

            StartCoroutine(DestroyOnTimer(cloud, _timeToDestroy));

            yield return new WaitForSeconds(timeBetweenIterations);
        }
    }
}
