using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UIGameplay : MonoBehaviour
{
    public static UIGameplay instance;
    [SerializeField] GameObject pauseMenuParent;
    [SerializeField] GameObject shopMenuParent;
    [SerializeField] GameObject resumeButton;
    [SerializeField] string mainMenuSceneName = "MainMenu";
    [SerializeField] GameObject pointsText;

    bool isPaused = false;
    bool inOptions = false;

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
        }
    }

    public void OnMainMenu()
    {
        pauseMenuParent.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void PointsAnim()
    {
        pointsText.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.2f).OnComplete(() => { pointsText.transform.localScale = Vector3.one; });
    }

}
