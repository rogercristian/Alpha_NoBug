using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public static ObjectPooler SharedInstance;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    //public List<GameObject> pooledObjects;
    //public GameObject objectToPool;
    //public int amountPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);

                objectsPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectsPool);
        }
        //pooledObjects = new List<GameObject>();
        //GameObject tmp;

        //for (int i = 0; i < amountPool; i++)
        //{
        //    tmp = Instantiate(objectToPool);
        //    tmp.SetActive(false);
        //    pooledObjects.Add(tmp);
        //}
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    //public GameObject GetPooledObject()
    //{
    //    for (int i = 0;i < amountPool; i++)
    //    {
    //        if (!pooledObjects[i].activeInHierarchy)
    //        {
    //            return pooledObjects[i];
    //        }
    //    }
    //    return null;
    //}


}
