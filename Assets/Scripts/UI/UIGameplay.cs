using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameplay : MonoBehaviour
{
    public static UIGameplay instance;
    [SerializeField] GameObject pauseMenuParent;
    [SerializeField] GameObject shopMenuParent;
    [SerializeField] string mainMenuSceneName = "MainMenu";

    bool isPaused = false;
    bool inOptions = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    public void OnPauseResumeGame()
    {
        if (!isPaused && !inOptions)
        {
            isPaused = true;
            Time.timeScale = 0;
            pauseMenuParent.SetActive(true);
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
}
