using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    public static UIGameplay instance;
    [SerializeField] GameObject pauseMenuParent;
    [SerializeField] GameObject resumeButton;
    [SerializeField] string mainMenuSceneName = "MainMenu";

    [Header("Shop")]
    [SerializeField] GameObject shopMenuParent;
    [SerializeField] GameObject[] shopButtons;
    [SerializeField] StoreUpgrade[] upgrades;
    [SerializeField] GameObject upgradeParent;
    [SerializeField] GameObject negativeEffectParent;
    [SerializeField] GameObject unlockedIconPrefab;
    [SerializeField] GameObject startNewDayButton;
    [SerializeField] NegativeEffectManager negativeEffects;

    bool isPaused = false;
    bool inOptions = false;
    bool thereIsButton = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (StoreUpgrade upgrade in upgrades)
        {
            upgrade.FillData();
        }
    }

    public void OnPauseResumeGame()
    {
        if (!isPaused && !inOptions)
        {
            pauseMenuParent.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
            EventSystem.current.SetSelectedGameObject(resumeButton);

        }
        else if (isPaused && !inOptions)
        {
            isPaused = false;
            Time.timeScale = 1;
            pauseMenuParent.SetActive(false);
        }
    }

    public void OnMainMenu()
    {
        pauseMenuParent.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void TryToBuy(int order)
    {
        if(upgrades[order].data.price <= GameManager.instance.Points)
        {
            Buy(order);
            GameManager.instance.Points -= upgrades[order].data.price;
        }
    }

    private void Buy(int _order)
    {
        shopButtons[_order].GetComponent<Button>().interactable = false;
        shopButtons[_order].GetComponentInChildren<TextMeshProUGUI>().text = "---";
        upgrades[_order].descriptionText.text = "Comprado";
        negativeEffects.ApplyAndRemoveRandomEffect();
        SpawnUpgradeIcon(upgrades[_order]);
    }

    public void SpawnUpgradeIcon(StoreUpgrade up)
    {
        GameObject go = Instantiate(unlockedIconPrefab, upgradeParent.transform);
        go.GetComponent<Image>().sprite = up.data.iconSprite;
    }

    public void SpawnNegativeEffectIcon()
    {
        Instantiate(unlockedIconPrefab, negativeEffectParent.transform);
    }

    public void SelectFirstButton()
    {
        thereIsButton = false;

        for(int i = 0; i < shopButtons.Length; i++)
        {
            Button button = shopButtons[i].GetComponent<Button>();
            if(button.interactable)
            {
                EventSystem.current.SetSelectedGameObject(shopButtons[i]);
                thereIsButton = true;
                break;
            }
        }

        if(!thereIsButton)
        {
            EventSystem.current.SetSelectedGameObject(startNewDayButton);
        }
    }
}
