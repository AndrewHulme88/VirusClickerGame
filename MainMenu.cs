using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject startTransition;
    [SerializeField] GameObject endTransition;
    [SerializeField] float sceneTransitionTime = 1f;
    [SerializeField] AudioClip clickSound;
    [SerializeField] string nextSceneName;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        endTransition.SetActive(false);
        startTransition.SetActive(true);
        StartCoroutine(DisableTransitionScreen());
    }

    public void StartNewGame()
    {
        Score.score = 0;

        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        StartCoroutine(TransitionToNewGame());
    }

    public void TitleMenu()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        StartCoroutine(TransitionToMenu());
    }

    public void HighScores()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        StartCoroutine(TransitionToHighScores());
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit");
    }

    public void GoToNextScene()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        StartCoroutine(TransitionToNextScene());
    }

    IEnumerator TransitionToNextScene()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator TransitionToNewGame()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("StoryScene1");
    }

    IEnumerator TransitionToMenu()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("TitleMenu");
    }

    IEnumerator TransitionToHighScores()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("HighScoresMenu");
    }

    IEnumerator DisableTransitionScreen()
    {
        yield return new WaitForSeconds(sceneTransitionTime);
        startTransition.SetActive(false);
    }
}
