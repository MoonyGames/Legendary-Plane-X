using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    protected float _timeBetweenIterations = 3f, _timeToDestroy = 7f;

    public static bool IsGenerating { get; set; } = false;

    protected List<GameObject> pooledObjects;

    [SerializeField]
    protected GameObject[] objectsToPool;
    [SerializeField]
    protected int _amountToPool;

    [SerializeField]
    protected Transform _parent;

    protected void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(objectsToPool[Random.Range(0, objectsToPool.Length)], _parent);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        IsGenerating = true;

        StartCoroutine(GenerateLooped(_timeBetweenIterations));
    }

    protected GameObject GetPooledObject()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }

        return null;
    }

    protected virtual IEnumerator GenerateLooped(float timeBetweenIterations)
    {
        yield return null;
    }

    protected IEnumerator DestroyOnTimer(GameObject cloud, float timeToDestroy)
    {
        yield return new WaitForSeconds(timeToDestroy);

        cloud.SetActive(false);
    }
}
