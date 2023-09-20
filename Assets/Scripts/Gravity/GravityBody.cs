using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;

    public Rigidbody body;
    public bool enableAttraction = true;

    public float gravity;

    public bool freezeRotation = false;
    void Start()
    {
        
        body = GetComponent<Rigidbody>();

        
        if (freezeRotation && enableAttraction)
        {
            body.constraints = RigidbodyConstraints.FreezeRotation;
        }

        body.useGravity = false;

    }

    void FixedUpdate()
    {
        if (enableAttraction)
        {
            attractor.Attract(transform, body, gravity);
        }
    }

    public void EnableAttraction()
    {
        enableAttraction = true;

        body.useGravity = false;

        if (enableAttraction)
        {
            body.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
}


