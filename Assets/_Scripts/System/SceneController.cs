using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject transition;
    [SerializeField] Animator transitionAnim;
    [SerializeField] private Image fade;
    
    private AsyncOperation op;
    private bool shouldFadeOut;
    private bool shouldFadeIn;

    string scene;

    private void Start()
    {
        //shouldFadeOut = true;
        //fade.color = new Color(0f, 0f, 0f, 1f);
        //transition.transform.localScale = new Vector2(0.4f, 0.4f);
        //transition.transform.DOScale(15f, 2f);
    }

    public void LoadScene(string sceneToLoad)
    {
        scene = sceneToLoad;
        //op = SceneManager.LoadSceneAsync(sceneToLoad);
        //op.allowSceneActivation = false;


        transitionAnim.SetTrigger("fade");
        Invoke("AllowScene", 1f);
        //shouldFadeIn = true;

        //transition.transform.DOScale(0.4f, 4f).OnComplete(() => { op.allowSceneActivation = true; });
    }

    public void AllowScene()
    {
        SceneManager.LoadScene(scene);
    }
    private void Update()
    {
        //if (shouldFadeIn)
        //    fade.color = new Color(0f, 0f, 0f, Mathf.Lerp(fade.color.a, 1f, 2f * Time.deltaTime));

        //if (shouldFadeOut)
        //    fade.color = new Color(0f, 0f, 0f, Mathf.Lerp(fade.color.a, 0f, 2f * Time.deltaTime));

        //if (fade.color.a == 0f)
        //    shouldFadeIn = false;
    }


    public void FadeOutDeath()
    {
        AudioManager.instance.FadeOut("DeathMusic");
    }

    public void FadeOutDayMusic()
    {

    }

    public void FadeOutNightMusic()
    {

    }
}
