using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    void Start()
    {
        scoreText.text = "Viruses Killed: " + Score.score.ToString();
        highScoreText.text = "High Score: " + Score.GetHighScore().ToString();
    }
}
