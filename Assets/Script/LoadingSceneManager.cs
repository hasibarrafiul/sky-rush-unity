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
    }

    IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(minimumLoadingTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(targetSceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // Display loading progress (e.g., update progress bar)
            print(operation.progress);
            if (operation.progress >= 0.2f)
            {
                zeroPercentBar.SetActive(false);
                twentyPercentBar.SetActive(true);
            }
            if (operation.progress >= 0.4f)
            {
                twentyPercentBar.SetActive(false);
                fortyPercentBar.SetActive(true);
            }
            if (operation.progress >= 0.6f)
            {
                fortyPercentBar.SetActive(false);
                sixtyPercentBar.SetActive(true);
            }
            if (operation.progress >= 0.8f)
            {
                sixtyPercentBar.SetActive(false);
                eightyPercentBar.SetActive(true);
            }
            if (operation.progress >= 0.9f)
            {
                // When the loading progress is nearly complete
                // (0.9f is considered fully loaded), allow scene activation
                eightyPercentBar.SetActive(false);
                hundredPercentBar.SetActive(true);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
