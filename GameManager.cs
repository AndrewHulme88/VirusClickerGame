using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [SerializeField] TextMeshProUGUI infectedScoreText;
    [SerializeField] TextMeshProUGUI bugsCaughtScoreText;
    [SerializeField] TextMeshProUGUI bugsLeftText;
    [SerializeField] string nextLevelString;
    [SerializeField] float sceneTransitionTime = 1f;

    public int bugsLeft = 20;
    public int mainframeHealth = 10;

    private SceneTransition sceneTransition;

    void Start()
    {
        UpdateScoreUI();
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    public void AssignUIElements(TextMeshProUGUI infectedScore, TextMeshProUGUI bugsCaught, TextMeshProUGUI bugsLeft)
    {
        infectedScoreText = infectedScore;
        bugsCaughtScoreText = bugsCaught;
        bugsLeftText = bugsLeft;
        UpdateScoreUI();
    }

    public void AddInfectedScore(int score)
    {
        mainframeHealth -= score;
        bugsLeft -= score;
        UpdateScoreUI();
    }

    public void AddBugsCaughtScore(int score)
    {
        Score.score += score;
        bugsLeft -= score;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        infectedScoreText.text = "Mainframe Health: " + mainframeHealth.ToString();
        bugsCaughtScoreText.text = "Bugs Killed: " + Score.score.ToString();
        bugsLeftText.text = "Bugs Remaining: " + bugsLeft.ToString();

        if (mainframeHealth <= 0)
        {
            StartCoroutine(GameOver());
        }

        if(bugsLeft <= 0)
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        sceneTransition.FadeOut();
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene(nextLevelString);
    }

    IEnumerator GameOver()
    {
        sceneTransition.FadeOut();
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("GameOver");
    }
}
