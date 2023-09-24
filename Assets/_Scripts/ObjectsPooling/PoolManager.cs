using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public GameObject[] smallObjPrefabs;
    public GameObject[] mediumObjPrefabs;
    public GameObject[] bigObjPrefabs;

    protected List<GameObject> allGameObjects = new List<GameObject>();   
    //public int poolSize;
    protected Queue<GameObject> objPool = new Queue<GameObject>();

 
    float spawnRatio;

    [Space]
    [Header("Spawn Ratios")]
    public float maxSpawnRatio = 5f;
    public float minSpawnRation = 0f;


    [Header("Negative Effects Variables")]
    public bool enableSpawn;
    public bool enableDestructionOnArrive;
    public bool enableExplosionOnArrive;
    [HideInInspector] public float gravityIncrease;

    [Header("Filter pool objects")]
    [SerializeField] int smallObjects;
    [SerializeField] int mediumObjects;
    [SerializeField] int bigObjects;
    private void Start()
    {
        spawnRatio = Random.Range(minSpawnRation, maxSpawnRatio);
        FirstInstantiations();
    }

    void FirstInstantiations()
    {
        for (int i = 0; i < smallObjects; i++)
        {
            InstantiateTypeOfGO(smallObjPrefabs);
        }

        for (int i = 0; i < mediumObjects; i++)
        {
            InstantiateTypeOfGO(mediumObjPrefabs);
        }
        for (int i = 0; i < bigObjects; i++)
        {
            InstantiateTypeOfGO(bigObjPrefabs);
        }
        allGameObjects =  ShuffleList(allGameObjects);

        for (int i = 0; i < allGameObjects.Count; i++)
        {
            objPool.Enqueue(allGameObjects[i]);
        }

    }

    List<GameObject> ShuffleList(List<GameObject> gameObjecList)
    {
        for (int i = 0; i < gameObjecList.Count; i++)
        {
            int rnd = Random.Range(0, i);
            var temp = gameObjecList[i];

            gameObjecList[i] = gameObjecList[rnd];
            gameObjecList[rnd] = temp;

        }

        return gameObjecList;
    }

    protected virtual void InstantiateTypeOfGO(GameObject[] gameObjects)
    {

        int a = Random.Range(0, gameObjects.Length);//aquí accedes a un objeto aleatorio
        GameObject newObj = Instantiate(gameObjects[a], transform); //instancias el objeto aleatorio

        //newObj.GetComponent<GravityBody>().attractor = GameManager.instance.planetAttractor;
        if (newObj.TryGetComponent(out FallingObject fallingObject))
        {
            fallingObject.objectBody.attractor = GameManager.instance.planetAttractor;
            fallingObject.Init(this);
            fallingObject.objectBody.gravity += gravityIncrease;
            fallingObject.destroyOnArrival = enableDestructionOnArrive;

        }

        allGameObjects.Add(newObj);
        newObj.SetActive(false);
        //objPool.Enqueue(newObj);    
        //newObj.SetActive(false);
    }

    public void ChangeValuesFromPools()
    {
        //Method Used to change values from negativeEffects
        foreach(GameObject o in objPool)
        {
            if (o.TryGetComponent(out FallingObject fallingObject))
            {
                fallingObject.objectBody.gravity = gravityIncrease;
                fallingObject.destroyOnArrival = enableDestructionOnArrive;
                fallingObject.explosionOnArrival = enableExplosionOnArrive;
            }
        }
    }
    void Update()
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
