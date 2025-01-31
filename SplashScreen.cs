using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] float splashDuration = 3f;
    [SerializeField] GameObject startTransition;
    [SerializeField] GameObject endTransition;
    [SerializeField] float sceneTransitionTime = 1f;
    [SerializeField] GameObject logo;
    [SerializeField] float logoDestroyTime = 0.8f;

    void Start()
    {
        endTransition.SetActive(false);
        startTransition.SetActive(true);
        Invoke("LoadNextScene", splashDuration);
    }

    void LoadNextScene()
    {
        StartCoroutine(TransitionToNextScene());
    }

    IEnumerator TransitionToNextScene()
    {
        endTransition.SetActive(true);
        Destroy(logo, logoDestroyTime);
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("TitleMenu");
    }
}
