using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudsGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector3 _minPosition, _maxPosition;

    [SerializeField]
    private float _timeBetweenIterations = 3f, _timeToDestroy = 7f;

    public bool IsGenerating { get; set; } = false;

    private List<GameObject> pooledObjects;

    [SerializeField]
    private GameObject[] objectsToPool;
    [SerializeField]
    private int _amountToPool;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(objectsToPool[Random.Range(0, objectsToPool.Length)]);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        IsGenerating = true;

        StartCoroutine(GenerateLooped(_timeBetweenIterations));
    }

    private GameObject GetPooledObject()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    private IEnumerator GenerateLooped(float timeBetweenIterations)
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

    private IEnumerator DestroyOnTimer(GameObject cloud, float timeToDestroy)
    {
        yield return new WaitForSeconds(timeToDestroy);

        cloud.SetActive(false);
    }
}
