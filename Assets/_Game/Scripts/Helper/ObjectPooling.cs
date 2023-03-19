using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    private List<GameObject> _pooledObject = new List<GameObject>();
    private int amoutToPool = 10;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private Transform parrent;

    private void Start()
    {
        for (int i = 0; i < amoutToPool; i++)
        {
            GameObject obj = Instantiate(pipePrefab, parrent.transform);
            obj.SetActive(false);
            _pooledObject.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _pooledObject.Count; i++)
        {
            if (!_pooledObject[i].activeInHierarchy)
            {
                return _pooledObject[i];
            }
        }
        return null;
    }
}
