using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeUpgrade : PlayerUpgrades
{
    [SerializeField] float growthReduction;

    public override void UnlockUpgrade()
    {
        base.UnlockUpgrade();
        character._playerCharacterGrow.growthReduction += growthReduction;
    }
}
