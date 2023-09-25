using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUpgrades : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter character;

    public float cost;
    [HideInInspector] public bool unlocked = false;

    [Header("Upgrade Variables")]
    [SerializeField] string upgradeName;

    [SerializeField] TextMeshProUGUI upgradeNameText;
    [SerializeField] TextMeshProUGUI upgradeCostText;
    [SerializeField] Button upgradeButton;

    [SerializeField] NegativeEffectManager negativeEffects;

    private void Start()
    {
        character = GameManager.instance.playerCharacter;
        SetUpShop();
    }

    public virtual void UnlockUpgrade()
    {        
        unlocked = true;
        upgradeCostText.SetText("Comprado");
        upgradeButton.image.color = Color.green;
        negativeEffects.ApplyAndRemoveRandomEffect();
        Debug.Log("Upgrade Unlocked");
    }

    public void SetUpShop()
    {
        upgradeNameText.SetText(upgradeName);
        upgradeCostText.SetText(cost.ToString());

        if (unlocked)
        {
            DisableButton();
        }
        else
        {
            if (GameManager.instance.Points < cost)
            {
                upgradeCostText.color = Color.red;
            }

            else
            {
                upgradeCostText.color = Color.black;
            }
        }
    }

    public void DisableButton()
    {
        UIGameplay.instance.SelectFirstButton();
    }

    public void BuyUpgrade()
    {
        if (GameManager.instance.Points >= cost && !unlocked)
        {
            GameManager.instance.Points -= cost;
            UnlockUpgrade();
        }
    }
}
