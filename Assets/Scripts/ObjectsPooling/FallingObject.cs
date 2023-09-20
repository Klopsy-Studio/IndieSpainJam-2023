using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public PoolManager poolManager { get; set; }

    [SerializeField] float velocity = 2f;

    RaycastHit raycastHit;

    bool planetDetected;

    public GameObject marker;
    public void Update()
    {
        if (!planetDetected)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, velocity);
            Vector3 dir = Vector3.zero - transform.position;
            if (Physics.Raycast(transform.position, dir, out raycastHit, 2f))
            {
                GetComponent<Rigidbody>().useGravity = true;
                Destroy(marker);
                planetDetected = true;
            }
        }
        

    }

    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;

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
