using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : PlayerUpgrades
{
    [SerializeField] float normalSpeedIncrease;
    [SerializeField] float swallowSpeedIncrease;


    public override void UnlockUpgrade()
    {
        base.UnlockUpgrade();
        character._playerCharacterMovement.moveSpeed += normalSpeedIncrease;
        character._playerCharacterMovement.swallowMoveSpeed += swallowSpeedIncrease;
    }
}
