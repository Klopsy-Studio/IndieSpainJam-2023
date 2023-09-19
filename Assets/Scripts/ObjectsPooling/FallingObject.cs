using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public PoolManager poolManager { get; set; }

    [SerializeField] float velocity = 2f;
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, velocity);
    }
    public void Init(PoolManager _poolManager)
    {
        poolManager = _poolManager;
    }

    
}
