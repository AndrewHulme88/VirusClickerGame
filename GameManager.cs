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

    public int bugsLeft = 20;
    public int mainframeHealth = 10;

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Start()
    {
        UpdateScoreUI();
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
            GameOver();
        }

        if(bugsLeft <= 0)
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(nextLevelString);
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
