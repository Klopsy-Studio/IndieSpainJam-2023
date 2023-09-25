using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTheGame : PlayerUpgrades
{
    [SerializeField] SceneController controller;
    public override void UnlockUpgrade()
    {
        AudioManager.instance.Play("Submit");
        unlocked = true;
        upgradeCostText.SetText("Comprado");
        upgradeButton.image.color = Color.green;
        controller.LoadScene("Victory");
        //Fill with win the game method
    }
}
