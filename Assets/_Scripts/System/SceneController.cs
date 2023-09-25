using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
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
