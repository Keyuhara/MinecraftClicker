using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Texture2D map;

    public static EnemySpawner instance;
    private List<GameObject> pooledObjects = new List <GameObject>();
    private int poolAmount = 50;

    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject skeleton;
    [SerializeField] private GameObject enderman;

    [SerializeField] private GameObject test;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < poolAmount; i++)
        {
            GameObject obj = Instantiate(zombie);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }


    // Update is called once per frame
    void Update()
    {
        Data.zombieTime += Time.deltaTime * Data.speed;
        Data.skeletonTime += Time.deltaTime * Data.speed;
        Data.endermanTime += Time.deltaTime * Data.speed;

        // zombie check
        if(Data.zombieTime >= Data.zombieInterval / Data.day) // DIFFICULTY
        {
            int x = Random.Range(0, map.width);
            int y = Random.Range(0, map.height);

            Color pixelColor = map.GetPixel(x, y);

            while( !(Data.green.Equals(pixelColor)) )
            {

                x = Random.Range(0, map.width);
                y = Random.Range(0, map.height);

                // get another x, y coordinates
                pixelColor = map.GetPixel(x, y);
            }

            GameObject zom = EnemySpawner.instance.GetPooledObject();
            
            Vector2 position = new Vector2(x, y);
            
            if(zom != null)
            {
                zom.transform.position = position;
                zom.SetActive(true);

                // Instantiate(enemy, position, Quaternion.identity, transform);
            }

            Data.zombieTime = 0;
        }

        // skeleton check
        if(Data.skeletonTime >= Data.skeletonInterval / Data.day) // DIFFICULTY
        {
            spawnEnemy(skeleton);
            Data.skeletonTime = 0;
        }

        // enderman check
        if(Data.endermanTime >= Data.endermanInterval / Data.day) // DIFFICULTY
        {
            spawnEnemy(enderman);
            Data.endermanTime = 0;
        }
    }

    public void spawnEnemy(GameObject enemy)
    {
        int x = Random.Range(0, map.width);
        int y = Random.Range(0, map.height);

        Color pixelColor = map.GetPixel(x, y);

        while( !(Data.green.Equals(pixelColor)) )
        {

            x = Random.Range(0, map.width);
            y = Random.Range(0, map.height);

            // get another x, y coordinates
            pixelColor = map.GetPixel(x, y);
        }
        
        Vector2 position = new Vector2(x, y);
        Instantiate(enemy, position, Quaternion.identity, transform);
    }
}
