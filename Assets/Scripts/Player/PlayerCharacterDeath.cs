using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacterDeath : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter parent;


    public int playerHitPoints = 1;
    [HideInInspector] public bool isPlayerDead;
    public void HitPlayer()
    {
        playerHitPoints--;

        if(playerHitPoints <= 0)
        {
            PlayerDie();
        }
    }
    public void PlayerDie()
    {
        //Make PlayerDie
        SceneManager.LoadScene(GameManager.instance.gameScene);
    }


}
