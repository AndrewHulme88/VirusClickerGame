using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infectedScoreText;
    [SerializeField] TextMeshProUGUI bugsCaughtScoreText;
    [SerializeField] public int bugsLeft = 20;
    [SerializeField] public int mainframeHealth = 10;

    public int bugsCaughtScore;

    void Start()
    {
        bugsCaughtScore = 0;
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
        bugsCaughtScore += score;
        bugsLeft -= score;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        infectedScoreText.text = "Mainframe Health: " + mainframeHealth.ToString();
        bugsCaughtScoreText.text = "Bugs Remaining: " + bugsLeft.ToString();
    }
}
