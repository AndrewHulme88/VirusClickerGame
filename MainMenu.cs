using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject startTransition;
    [SerializeField] GameObject endTransition;
    [SerializeField] float sceneTransitionTime = 1f;

    private void Start()
    {
        endTransition.SetActive(false);
        startTransition.SetActive(true);
        StartCoroutine(DisableTransitionScreen());
    }

    public void StartNewGame()
    {
        StartCoroutine(TransitionToNewGame());
    }

    public void TitleMenu()
    {
        StartCoroutine(TransitionToMenu());
    }

    IEnumerator TransitionToNewGame()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("Scene1");
    }

    IEnumerator TransitionToMenu()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("TitleMenu");
    }

    IEnumerator DisableTransitionScreen()
    {
        yield return new WaitForSeconds(sceneTransitionTime);
        startTransition.SetActive(false);
    }
}
