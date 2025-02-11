using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] int _poolSize = 15;
    [SerializeField] List<GameObject> _pooledObjects;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj;

        for (int i = 0; i < _poolSize; i++)
        {
            obj = Instantiate(_prefab);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }

    }

    // Update is called once per frame
    public GameObject GetPooledObject(Vector3 position, Quaternion rotation)
    {
        for (int i =0; i < _poolSize; i++)
        {
            if(!_pooledObjects[i].activeInHierarchy)
            {
                GameObject objectToSpawn;
                objectToSpawn = _pooledObjects[i];
                objectToSpawn.transform.position = position;
                objectToSpawn.transform.rotation = rotation;
                return objectToSpawn;
            }
        }

        return null;
    }
}
