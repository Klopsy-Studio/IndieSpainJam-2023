using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTheGame : PlayerUpgrades
{

    public override void UnlockUpgrade()
    {
        AudioManager.instance.Play("Submit");
        unlocked = true;
        upgradeCostText.SetText("Comprado");
        upgradeButton.image.color = Color.green;
        //Fill with win the game method
    }
}
