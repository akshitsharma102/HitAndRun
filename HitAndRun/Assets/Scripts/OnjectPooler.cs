using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static OnjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }

    public List<pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDiscionary;
    void Start()
    {
        poolDiscionary = new Dictionary<string, Queue<GameObject>>();
        foreach (pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDiscionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject spawnFormPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDiscionary.ContainsKey(tag))
        {
            Debug.LogWarning("tag " + tag + " dosentExist.");
            return null;
        }


        GameObject objecttospawn = poolDiscionary[tag].Dequeue();
        objecttospawn.SetActive(true);
        objecttospawn.transform.position = position;
        objecttospawn.transform.rotation = rotation;
        PlainSpawnner.Instance.getNextTransform(objecttospawn.transform.GetChild(0).transform.position);
        poolDiscionary[tag].Enqueue(objecttospawn);

        return objecttospawn;
    }
    
}
