using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter character;


    [HideInInspector] public bool unlocked = false;

    private void Start()
    {
        character = GameManager.instance.playerCharacter;
    }

    public virtual void UnlockUpgrade()
    {
        Debug.Log("Upgrade Unlocked");
    }
}
