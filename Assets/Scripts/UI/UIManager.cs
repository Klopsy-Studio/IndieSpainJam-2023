using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] string mainMenuSceneName = "MainMenu";
    [SerializeField] string gameSceneName = "GameScene";
    [SerializeField] GameObject optionsMenuParent;
    [SerializeField] GameObject mainMenuParent;
    [SerializeField] GameObject pauseMenuParent;

    bool isPaused = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void OnGameStart()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OnPauseResumeGame()
    {
        if(!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    public void OnOptions(bool isOptions)
    {
        optionsMenuParent.SetActive(isOptions);
        mainMenuParent.SetActive(!isOptions);
    }

    public void OnMainMenu()
    {
        pauseMenuParent.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
