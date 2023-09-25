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
    [SerializeField] GameObject startNewDayButton;

    bool isPaused = false;
    bool inOptions = false;
    bool thereIsButton = false;

    private void Awake()
    {
        instance = this;
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
            GameManager.instance.SetGameState(GameStates.Night);
        }
    }

    public void OnMainMenu()
    {
        pauseMenuParent.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneName);
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
