using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalPoolManager : PoolManager
{
    [Header("Spawn Area")]
    public float xOffset = 15f;
    public float yOffset = 15f;
    public float zOffset = 1f;

   
    protected override void RandomSpawns()
    {
        Vector3 newRandomPos = transform.position + new Vector3(Random.Range(-xOffset, xOffset), Random.Range(-yOffset, yOffset), Random.Range(-zOffset, zOffset));
      
        GameManager.instance.AddObjectToList(GetObjFromPool(newRandomPos, Quaternion.identity).GetComponent<FallingObject>());
    }

    protected override void InstantiateTypeOfGO(GameObject[] gameobjects)
    {
        //int a = Random.Range(0, gameobjects.Length);
        //GameObject newObj = Instantiate(gameobjects[a]);

        ////newObj.GetComponent<GravityBody>().attractor = GameManager.instance.planetAttractor;
        //if (newObj.TryGetComponent(out FallingObject fallingObject))
        //{
        //    fallingObject.objectBody.attractor = GameManager.instance.planetAttractor;
        //    fallingObject.Init(this);
        //}
        //objPool.Enqueue(newObj);
        //newObj.SetActive(false);

        int a = Random.Range(0, gameobjects.Length);//aquí accedes a un objeto aleatorio
        GameObject newObj = Instantiate(gameobjects[a]); //instancias el objeto aleatorio

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



    }
}
