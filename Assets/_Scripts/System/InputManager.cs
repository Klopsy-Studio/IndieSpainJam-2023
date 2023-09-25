using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private PlayerControls controls;

    [Header("References")]
    [SerializeField] private PlayerCharacter playerCharacter;

    private Vector2 axisVector;
    private bool swallowInputValue;

    private void OnEnable() { controls.Default.Enable(); }
    private void OnDisable() { controls.Default.Disable(); }

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void Start()
    {
        controls.Default.Movement.performed += ctx => axisVector = ctx.ReadValue<Vector2>();
        controls.Default.Movement.canceled += ctx => axisVector = Vector2.zero;

        controls.Default.Swallow.performed += ctx => swallowInputValue = ctx.ReadValueAsButton();
        controls.Default.Swallow.canceled += ctx => swallowInputValue = false;

        controls.Default.Pause.performed += OnPauseInput;
    }

    private void Update()
    {
        MovementInput();
        OnSwallowInput();
    }

    void MovementInput()
    {
        if (playerCharacter.CurrentPlayerState != PlayerStates.Death && GameManager.instance.CurrentGameState == GameStates.Night)
        {
            //Vector3 velocity = playerCharacter._playerCharacterMovement.rigidbodyCmp.velocity;
            //Vector3 input = new Vector3(axisVector.x, 0, axisVector.y);
            //Vector3.SmoothDamp(playerCharacter._playerCharacterMovement.moveDirection, input, ref velocity, 0.2f, 0f);
            playerCharacter._playerCharacterMovement.moveDirection = new Vector3(axisVector.x, 0, axisVector.y);

        }
    }

    void OnSwallowInput()
    {
        if (playerCharacter.CurrentPlayerState != PlayerStates.Death && GameManager.instance.CurrentGameState == GameStates.Night)
            playerCharacter.swallowInput = swallowInputValue;
    }

    void OnPauseInput(InputAction.CallbackContext context)
    {
        if (playerCharacter.CurrentPlayerState != PlayerStates.Death)
        {
            GameManager.instance.SetGameState(GameStates.Pause);
            UIGameplay.instance.OnPauseResumeGame();
        }
    }
}
