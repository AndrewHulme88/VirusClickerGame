using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoresText;

    void Start()
    {
        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        int[] highScores = Score.GetHighScores();
        string scoreText = "";

        for(int i = 0; i < highScores.Length; i++)
        {
            scoreText += (i + 1) + ". Viruses Killed: " + highScores[i] + "\n";
        }

        highScoresText.text = scoreText;
    }
}
