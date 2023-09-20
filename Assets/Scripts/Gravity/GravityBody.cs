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

        if (freezeRotation)
        {
            body.constraints = RigidbodyConstraints.FreezeRotation;
        }

        body.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enableAttraction)
        {
            attractor.Attract(transform, body, gravity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}


