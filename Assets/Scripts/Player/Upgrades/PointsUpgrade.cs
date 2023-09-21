using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsUpgrade : PlayerUpgrades
{
    [SerializeField] float multiplierIncrease;

    public override void UnlockUpgrade()
    {
        base.UnlockUpgrade();
        GameManager.instance.pointsMultiplier += multiplierIncrease;
    }
}
