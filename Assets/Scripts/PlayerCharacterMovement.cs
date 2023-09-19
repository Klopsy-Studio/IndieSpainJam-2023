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


    private void Start()
    {
        currentMoveSpeed = moveSpeed;
    }


    private void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }


    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + transform.TransformDirection(moveDirection * currentMoveSpeed * Time.deltaTime));
    }


    public void ChangeToMoveSpeed() { currentMoveSpeed = moveSpeed; }
    public void ChangeToSwallowSpeed()
    {
        currentMoveSpeed = swallowMoveSpeed;
    }



}
