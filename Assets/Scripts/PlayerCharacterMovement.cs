using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerCharacter playerCharacter;
    [SerializeField] private Rigidbody rigidbody;

    [Header("Parameters")]
    [SerializeField] float moveSpeed;
    [SerializeField] float swallowMoveSpeed;
    private float currentMoveSpeed;
    private Vector3 moveDirection;

    public GameObject model;

    private void Start()
    {
        currentMoveSpeed = moveSpeed;
    }


    private void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }


    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(moveDirection * currentMoveSpeed * Time.deltaTime));

        model.transform.localRotation = Quaternion.LookRotation(moveDirection.normalized, Vector3.up);

        //model.transform.rotation = Quaternion.LookRotation(moveDirection, transform.up);
    }

    public void HandleRotation()
    {


        //if (moveDirection.z == 1)
        //{
        //    Mathf.Lerp(transform.rotation.y, 90, Time.deltaTime * 5);
        //}

        //if (moveDirection.z == -1)
        //{
        //    Mathf.Lerp(transform.rotation.y, -90, Time.deltaTime * 5);
        //}
    }

    public void ChangeToMoveSpeed() { currentMoveSpeed = moveSpeed; }
    public void ChangeToSwallowSpeed()
    {
        currentMoveSpeed = swallowMoveSpeed;
    }



}
