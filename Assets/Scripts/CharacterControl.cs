using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterControl : MonoBehaviour
{
    [Header("PlayerSpeeds")]

    public float moveSpeed;
    public float swallowSpeed;
    private float speed;

    private Vector3 moveDirection;
    private Rigidbody bodyRigid;


    #region PlayerStates
    private PlayerStates _playerState;

    public PlayerStates PlayerState
    {
        get
        {
            return _playerState;
        }

        set
        {
            _playerState = value;

            switch (_playerState)
            {
                case PlayerStates.Move:
                    break;
                case PlayerStates.Swallow:
                    break;
                case PlayerStates.Death:
                    break;
                default:
                    break;
            }
        }

    }
    #endregion
    void Start()
    {
        bodyRigid = GetComponent<Rigidbody>();
        speed = moveSpeed;
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

