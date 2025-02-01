using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject startTransition;
    [SerializeField] GameObject endTransition;
    [SerializeField] float sceneTransitionTime = 1f;
    [SerializeField] float waitTime = 5f;

    void Start()
    {
        endTransition.SetActive(false);
        startTransition.SetActive(true);
        scoreText.text = "Viruses Killed: " + Score.score.ToString();
        highScoreText.text = "High Score: " + Score.GetHighScore().ToString();
        StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(TransitionToNextScene());
    }

    IEnumerator TransitionToNextScene()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("EndCredits");
    }
}
