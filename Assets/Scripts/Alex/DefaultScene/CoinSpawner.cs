using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner SharedInstance;

    public List<GameObject> pooledObjects;
    public GameObject[] objectsToPool;
    public int amountToPool;
    public int objectsActive = 0;
    float spawnTimer = 0;
    public float maxActiveObjects;
    public float spawnFrequensy;

    public List<AudioClip> coinClips;

    void Awake()
    {
        SharedInstance = this;
        for (int i = 0; i < 36; i++)
        {
            coinClips.Add(Resources.Load("Audio/CoinSounds/Coins_Single (" + i + ")")as AudioClip);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            int chance = Random.Range(0, 101);
            int id;
            if (chance < 50)
            {
                id = 0;
            }
            else if (chance > 50 && chance < 85)
            {
                id = 1;
            }
            else
            {
                id = 2;
            }
            GameObject obj = (GameObject)Instantiate(objectsToPool[id]);
            obj.GetComponent<CoinBehaviour>().SetClip(coinClips[Random.Range(0, coinClips.Count)]);
            Debug.Log(id);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            int randomObject = Random.Range(0, pooledObjects.Count - 1);
            if (!pooledObjects[randomObject].activeInHierarchy)
            {
                objectsActive++;
                return pooledObjects[randomObject];
            }
        }
        return null;
    }
    public void SpawnBall()
    {
        GameObject ball = SharedInstance.GetPooledObject();
        if (ball != null)
        {
            ball.transform.position = new Vector3(Random.Range(-14, 14), transform.position.y, Random.Range(-14, 14));
           // ball.transform.rotation = transform.rotation;
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
