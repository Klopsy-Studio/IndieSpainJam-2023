using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public PoolManager poolManager { get; set; }

    [SerializeField] float velocity = 2f;

    RaycastHit raycastHit;
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, velocity);
        Vector3 dir = Vector3.zero - transform.position;
        if(Physics.Raycast(transform.position, dir, out raycastHit, 2f))
        {
            //TODO debe detectar al planeta
            DeactivateItself();
        }

    }
    public void Init(PoolManager _poolManager)
    {
        poolManager = _poolManager;
    }

    public void DeactivateItself()
    {
        poolManager.ReturnObjToPool(this.gameObject);
    }

    
}
