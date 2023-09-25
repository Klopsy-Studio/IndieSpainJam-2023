using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject transition;
    [SerializeField] private Image fade;
    
    private AsyncOperation op;
    private bool shouldFadeOut;
    private bool shouldFadeIn;

    private void Start()
    {
        shouldFadeIn = true;
        fade.color = new Color(0f, 0f, 0f, 1f);
        transition.transform.localScale = new Vector2(0.33f, 0.33f);
        transition.transform.DOScale(15f, 2f);
    }

    public void LoadScene(string sceneToLoad)
    {
        op = SceneManager.LoadSceneAsync(sceneToLoad);
        op.allowSceneActivation = false;

        shouldFadeOut = true;

        transition.transform.DOScale(0.33f, 2f).OnComplete(() => { op.allowSceneActivation = true; });
    }

    private void Update()
    {
        if (shouldFadeOut)
            fade.color = new Color(0f, 0f, 0f, Mathf.Lerp(fade.color.a, 1f, 2f * Time.deltaTime));

        if (shouldFadeIn)
            fade.color = new Color(0f, 0f, 0f, Mathf.Lerp(fade.color.a, 0f, 2f * Time.deltaTime));

        if (fade.color.a == 0f)
            shouldFadeIn = false;
    }
}
