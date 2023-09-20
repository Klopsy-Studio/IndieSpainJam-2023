using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public GameObject[] objPrefabs;
    public int poolSize;
    private Queue<GameObject> objPool = new Queue<GameObject>();

    [Header("Spawn Area")]
    [SerializeField] float xOffset = 15f;
    [SerializeField] float yOffset = 15f;
    [SerializeField] float zOffset = 1f;

    float spawnRatio;

    [Space]
    [Header("Spawn Ratios")]
    [SerializeField] float maxSpawnRatio = 5f;
    [SerializeField] float minSpawnRation = 0f;
    private void Start()
    {
        spawnRatio = Random.Range(minSpawnRation, maxSpawnRatio);
        for (int i = 0; i < poolSize; i++)
        {
            int a = Random.Range(0, objPrefabs.Length);
            GameObject newObj = Instantiate(objPrefabs[a], transform);
            newObj.GetComponent<GravityBody>().attractor = GameManager.instance.planetAttractor;
            if(newObj.TryGetComponent(out FallingObject fallingObject))
            {
                fallingObject.Init(this);
            }
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
            spawnRatio = Random.Range(minSpawnRation, maxSpawnRatio);
        }

    }
    public void RandomSpawns()
    {
        //Vector3 newRandomPos = transform.position + new Vector3 (Random.Range(-xOffset, xOffset), Random.Range(-yOffset, yOffset), Random.Range(-zOffset, zOffset));
        Vector3 newRandomSurfaceSpherePos = Random.onUnitSphere * 10f;
        GetObjFromPool(newRandomSurfaceSpherePos, Quaternion.identity); 
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
