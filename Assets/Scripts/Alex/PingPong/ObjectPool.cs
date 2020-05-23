using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool SharedInstance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public int objectsActive=0;
    float spawnTimer = 0;
    public float maxActiveObjects;
    public float spawnFrequensy;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                objectsActive++;
                return pooledObjects[i];
            }
        }
        return null;
    }
    public void SpawnBall()
    {
        GameObject ball = SharedInstance.GetPooledObject();
        if (ball != null)
        {
            ball.transform.position = transform.position;
            ball.transform.rotation = transform.rotation;
            ball.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (objectsActive < maxActiveObjects)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnFrequensy)
            {
                if (spawnFrequensy >= .5f)
                {
                    spawnFrequensy -= 0.1f;
                }
                SpawnBall();
                spawnTimer = 0;
            }
        }
    }
}
