using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public GameObject[] objPrefabs;
    public int poolSize;
    protected Queue<GameObject> objPool = new Queue<GameObject>();

 
    float spawnRatio;

    [Space]
    [Header("Spawn Ratios")]
    [SerializeField] float maxSpawnRatio = 5f;
    [SerializeField] float minSpawnRation = 0f;


    public bool enableSpawn;
    private void Start()
    {
        spawnRatio = Random.Range(minSpawnRation, maxSpawnRatio);
        for (int i = 0; i < poolSize; i++)
        {
            FirstInstantiations();
        }   
    }

    protected virtual void FirstInstantiations()
    {
        int a = Random.Range(0, objPrefabs.Length);
        GameObject newObj = Instantiate(objPrefabs[a], transform);

        //newObj.GetComponent<GravityBody>().attractor = GameManager.instance.planetAttractor;
        if (newObj.TryGetComponent(out FallingObject fallingObject))
        {
            fallingObject.objectBody.attractor = GameManager.instance.planetAttractor;
            fallingObject.Init(this);
        }
        objPool.Enqueue(newObj);
        newObj.SetActive(false);
    }

    protected virtual void Update()
    {
        if (enableSpawn)
        {
            spawnRatio -= Time.deltaTime;
            if (spawnRatio <= 0)
            {
                RandomSpawns();
                spawnRatio = Random.Range(minSpawnRation, maxSpawnRatio);
            }
        }

        Debug.Log("hello there");
    }
    protected virtual void RandomSpawns()
    {
        //Vector3 newRandomPos = transform.position + new Vector3(Random.Range(-xOffset, xOffset), Random.Range(-yOffset, yOffset), Random.Range(-zOffset, zOffset));
        Vector3 newRandomSurfaceSpherePos = Random.onUnitSphere * 100f;
        GameManager.instance.AddObjectToList(GetObjFromPool(newRandomSurfaceSpherePos, Quaternion.identity).GetComponent<FallingObject>()); 
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
