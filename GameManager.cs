using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infectedScoreText;
    [SerializeField] TextMeshProUGUI bugsCaughtScoreText;

    public int infectedScore;
    public int bugsCaughtScore;

    void Start()
    {
        infectedScore = 0;
        bugsCaughtScore = 0;
        UpdateScoreUI();
    }

    public void AddInfectedScore(int score)
    {
        infectedScore += score;
        UpdateScoreUI();
    }

    public void AddBugsCaughtScore(int score)
    {
        bugsCaughtScore += score;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        infectedScoreText.text = "Infected: " + infectedScore.ToString();
        bugsCaughtScoreText.text = "Bugs Caught: " + bugsCaughtScore.ToString();
    }
}
