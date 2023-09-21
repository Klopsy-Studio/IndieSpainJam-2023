using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointsUpgrade : PlayerUpgrades
{

    [SerializeField] int healthPointIncrease;
    public override void UnlockUpgrade()
    {
        base.UnlockUpgrade();
        character._playerCharacterDeath.playerHitPoints += healthPointIncrease;
    }
}
