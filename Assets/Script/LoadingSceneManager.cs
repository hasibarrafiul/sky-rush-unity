using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string targetSceneName;
    public float minimumLoadingTime = 2f; // Minimum loading time in seconds
    public GameObject zeroPercentBar;
    public GameObject twentyPercentBar;
    public GameObject fortyPercentBar;
    public GameObject sixtyPercentBar;
    public GameObject eightyPercentBar;
    public GameObject hundredPercentBar;


    void Start()
    {
        StartCoroutine(LoadSceneAsync());
        zeroPercentBar.SetActive(true);
        StartCoroutine(loadingBar());
    }
    
    IEnumerator loadingBar()
    {
        yield return new WaitForSeconds(0.5f);
        zeroPercentBar.SetActive(false);
        twentyPercentBar.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        twentyPercentBar.SetActive(false);
        fortyPercentBar.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fortyPercentBar.SetActive(false);
        sixtyPercentBar.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sixtyPercentBar.SetActive(false);
        eightyPercentBar.SetActive(true);
    }

    IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(minimumLoadingTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(targetSceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            
            if (operation.progress >= 0.9f)
            {
                eightyPercentBar.SetActive(false);
                hundredPercentBar.SetActive(true);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
