using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightTimeUpgrade : PlayerUpgrades
{
    [SerializeField] float timeIncrease;

    public override void UnlockUpgrade()
    {
        base.UnlockUpgrade();
        GameManager.instance.Timer += timeIncrease;
    }
}
