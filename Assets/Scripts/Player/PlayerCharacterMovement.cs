using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerCharacter playerCharacter;
    [SerializeField] private Rigidbody rigidbodyCmp;
    [SerializeField] private GameObject model;

    [Header("Parameters")]
    [HideInInspector] public Vector3 moveDirection;
    public float moveSpeed;
    public float swallowMoveSpeed;
    private float currentMoveSpeed;

    [SerializeField] float rotationSpeed;

    [SerializeField] List<AudioSource> moveSounds;
    AudioSource currentMoveAudio;
    bool movePlaying;
    float currentMoveTimer;
    private void Start()
    {
        currentMoveSpeed = moveSpeed;
    }


    private void Update()
    {
        if (moveDirection != Vector3.zero)
        {
            if(currentMoveAudio == null)
            {
                HandleMovementSound();
            }
            if (movePlaying)
            {
                currentMoveTimer -= Time.deltaTime;

                if (currentMoveTimer <= 0)
                {
                    movePlaying = false;
                }
            }

            else
            {
                HandleMovementSound();
            }
        }
        //if (playerCharacter.CurrentPlayerState == PlayerStates.Move || playerCharacter.CurrentPlayerState == PlayerStates.Swallow)
        //    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }


    private void FixedUpdate()
    {
        rigidbodyCmp.MovePosition(rigidbodyCmp.position + transform.TransformDirection(moveDirection * currentMoveSpeed * Time.deltaTime));

        if (moveDirection.magnitude > 0)
            model.transform.localRotation = Quaternion.LookRotation(moveDirection.normalized*rotationSpeed, Vector3.up);
    }


    public void ChangeToMoveSpeed() { currentMoveSpeed = moveSpeed; }
    public void ChangeToSwallowSpeed() { currentMoveSpeed = swallowMoveSpeed; }

    public void HandleMovementSound()
    {
        AudioSource a = moveSounds[Random.Range(0, moveSounds.Count)];
        
        while(a == currentMoveAudio)
        {
            a = moveSounds[Random.Range(0, moveSounds.Count)];
        }

        currentMoveAudio = a;
        currentMoveTimer = currentMoveAudio.clip.length;
        currentMoveAudio.Play();
        movePlaying = true;
    }
}
