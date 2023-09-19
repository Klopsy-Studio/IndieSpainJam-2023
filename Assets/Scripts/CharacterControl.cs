using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterControl : MonoBehaviour
{
    [Header("PlayerSpeeds")]
    [SerializeField] float moveSpeed;
    [SerializeField] float swallowSpeed;
    private float speed;

    [Header("Player Events")]
    [SerializeField] UnityEvent changeToMove;
    [SerializeField] UnityEvent changeToSwallow;
    [SerializeField] UnityEvent changeToDeath;

    [Header("Swallow Variables")]

    [SerializeField] float swallowCooldown;
    [SerializeField] float swallowTimer;
    float _swallowCooldown;
    float _swallowTimer;


    bool swallowing;
    bool swallowInCooldown = false;
    //bool CanSwallow => ;




    private Vector3 moveDirection;
    private Rigidbody bodyRigid;


    #region PlayerStates
    private PlayerStates _currentPlayerState;

    public PlayerStates CurrentPlayerState
    {
        get
        {
            return _currentPlayerState;
        }

        set
        {
            _currentPlayerState = value;

            switch (_currentPlayerState)
            {
                case PlayerStates.Move:
                    changeToMove.Invoke();
                    break;
                case PlayerStates.Swallow:
                    changeToSwallow.Invoke();
                    break;
                case PlayerStates.Death:
                    changeToDeath.Invoke();
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

        _swallowCooldown = swallowCooldown;
        _swallowTimer = swallowTimer;

        SetState(PlayerStates.Move);
    }
    
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (!swallowInCooldown && Input.GetKey(KeyCode.Mouse0))
        {
            if (!swallowing)
            {
                SetState(PlayerStates.Swallow);
                swallowing = true;
            }

            if (HandleSwallowTimer())
            {
                EndSwallow();
            }
        }

        if(swallowing && Input.GetKeyUp(KeyCode.Mouse0))
        {
            swallowing = false;
            ResetSwallowTimerValue();
            swallowInCooldown = true;
            SetState(PlayerStates.Move);
        }


        if (swallowInCooldown)
        {
            if (HandleSwallowCooldown())
            {
                EndSwallowCooldown();
            }
        }
    }
    public void EndSwallowCooldown()
    {
        ResetSwallowCooldownValue();
        swallowInCooldown = false;
    }
    public void EndSwallow()
    {
        swallowing = false;
        swallowInCooldown = true;
        ResetSwallowTimerValue();
        SetState(PlayerStates.Move);
    }
    public bool HandleSwallowTimer()
    {
        _swallowTimer -= Time.deltaTime;
        return _swallowTimer <= 0;
    }

    public bool HandleSwallowCooldown()
    {
        _swallowCooldown -= Time.deltaTime;
        return _swallowCooldown <= 0;
    }

    public void ResetSwallowCooldownValue()
    {
        _swallowCooldown = swallowCooldown;

    }
    public void ResetSwallowTimerValue()
    {
        _swallowTimer = swallowTimer;
    }
    private void FixedUpdate()
    {
        bodyRigid.MovePosition(bodyRigid.position + transform.TransformDirection(moveDirection * speed * Time.deltaTime));
    }


    public void SetState(PlayerStates state)
    {
        CurrentPlayerState = state; 
    }

    public void ChangeToMoveSpeed()
    {
        speed = moveSpeed;
    }

    public void ChangeToSwallowSpeed()
    {
        speed = swallowSpeed;
    }


    public void ChangeMaterial(Material material)
    {
        GetComponent<MeshRenderer>().material = material;
    }
}

