using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private Vector3 moveDirection;
    private Rigidbody bodyRigid;
    void Start()
    {
        bodyRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        bodyRigid.MovePosition(bodyRigid.position + transform.TransformDirection(moveDirection * speed * Time.deltaTime));
    }
}

