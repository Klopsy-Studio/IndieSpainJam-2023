using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacterDeath : MonoBehaviour
{
    [HideInInspector] public PlayerCharacter parent;
    [SerializeField] private GameObject deathCam;
    [SerializeField] private GameObject deathVFX;

    public int playerHitPoints = 1;
    [HideInInspector] public bool isPlayerDead;
    [SerializeField] SceneController controller;
    public void HitPlayer()
    {
        playerHitPoints--;

        if(playerHitPoints <= 0)
        {
            parent.SetState(PlayerStates.Death);
        }
    }

    public void PlayerDie()
    {
        if (!isPlayerDead)
        {
            isPlayerDead = true;
            Debug.Log("Die");
            GameManager.instance.ReturnAllItems();

            if (deathCam != null)
            {
                deathCam.SetActive(true);
            }
            AudioManager.instance.FadeOut("NightMusic");
            AudioManager.instance.FadeIn("DeathMusic");
            GameManager.instance.SetGameState(GameStates.GameOver);
            Invoke("ChangeToDieScreen", 2f);
            if (deathVFX != null)
            {
                StartCoroutine(InstantiateDeathVFX());
            }
        }
    }

    public void ChangeToDieScreen()
    {
        controller.LoadScene("Retry");
    }
    IEnumerator InstantiateDeathVFX()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(deathVFX, transform, false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Object"))
        {
            if(collision.collider.transform.parent.TryGetComponent<FallingObject>(out FallingObject o))
            {
                if (o.falling)
                {
                    o.DeactivateItself();
                    HitPlayer();
                }
            }
        }
    }
}
