using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string gameSceneName = "Game";
    [SerializeField] GameObject mainMenuParent;
    [SerializeField] GameObject optionsMenuParent;
    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject returnButton;
    [SerializeField] string sceneToLoad;

    public void OnGameStart()
    {
        LoadScene();
        mainMenuParent.SetActive(false);
    }

    public void OnOptions(bool isOptions)
    {
        optionsMenuParent.SetActive(isOptions);
        mainMenuParent.SetActive(!isOptions);

        if (isOptions)
        {
            EventSystem.current.SetSelectedGameObject(returnButton);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(startGameButton);
        }
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!op.isDone)
        {

            yield return null;
        }
    }
    public void LoadScene()
    {
        StartCoroutine(LoadSceneAsync());
    }
}
