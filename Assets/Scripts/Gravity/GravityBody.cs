using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;

    public Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeRotation;
        body.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        attractor.Attract(transform, body);
    }


}


