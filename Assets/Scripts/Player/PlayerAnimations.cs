using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter parent;

    [SerializeField] Animator playerAnim;
    [SerializeField] GameObject modelToRotate;
    [SerializeField] float rotationSpeed;

    public void SetAnimState(string parameter, bool value)
    {
        playerAnim.SetBool(parameter, value);
    }

    public void RotateModel()
    {
        if(parent._playerCharacterMovement.moveDirection != Vector3.zero && parent.CurrentPlayerState != PlayerStates.Swallow)
        {
            modelToRotate.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
            SetAnimState("moving", true);
        }
        else
        {
            modelToRotate.transform.localRotation = Quaternion.Euler(0, 0, 0);
            SetAnimState("moving", false);

        }
    }

    private void Update()
    {
        RotateModel();
    }

}
