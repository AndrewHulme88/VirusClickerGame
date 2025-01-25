using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] float sceneTransitionTime = 1f;

    private SceneTransition sceneTransition;

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
        sceneTransition.FadeOut();
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("Scene1");
    }

    IEnumerator TransitionToMenu()
    {
        sceneTransition.FadeOut();
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("TitleMenu");
    }
}
