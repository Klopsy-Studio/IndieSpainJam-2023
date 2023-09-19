using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public GameObject objPrefab;
    public int poolSize;
    private Queue<GameObject> objPool = new Queue<GameObject>();

    [SerializeField] float xOffset = 15f;
    [SerializeField] float yOffset = 15f;
    [SerializeField] float zOffset = 1f;

    float spawnRatio;
    [SerializeField] float maxSpawnRatio = 5f;
    private void Start()
    {
        spawnRatio = maxSpawnRatio;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(objPrefab, transform);
            objPool.Enqueue(newObj);
            newObj.SetActive(false);
        }   
    }

    private void Update()
    {
        spawnRatio -= Time.deltaTime;
        if (spawnRatio <= 0)
        {
            RandomSpawns();
            spawnRatio = maxSpawnRatio;
        }
       
    }
    public void RandomSpawns()
    {
        Vector3 newRandomPos = transform.position + new Vector3 (Random.Range(-xOffset, xOffset), Random.Range(-yOffset, yOffset), Random.Range(-zOffset, zOffset));
        GameObject newObject = GetObjFromPool(newRandomPos, Quaternion.identity); 
    }

    public GameObject GetObjFromPool(Vector3 newPos, Quaternion newRotation)
    {
        GameObject newObj = objPool.Dequeue();
        newObj.SetActive(true);
        newObj.transform.SetPositionAndRotation(newPos, newRotation);

        return newObj;
    }

    public void ReturnObjToPool(GameObject go)
    {
        go.SetActive(false);
        objPool.Enqueue(go);
    }


}
