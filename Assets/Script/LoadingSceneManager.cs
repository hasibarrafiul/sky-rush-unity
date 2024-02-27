using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string targetSceneName;
    public float minimumLoadingTime = 2f; // Minimum loading time in seconds

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        yield return new WaitForSeconds(minimumLoadingTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(targetSceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // Display loading progress (e.g., update progress bar)

            if (operation.progress >= 0.9f)
            {
                // When the loading progress is nearly complete
                // (0.9f is considered fully loaded), allow scene activation
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
