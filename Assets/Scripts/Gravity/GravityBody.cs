using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;

    public Rigidbody body;
    public bool enableAttraction = true;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeRotation;
        body.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enableAttraction)
        {
            attractor.Attract(transform, body);
        }
    }


}


