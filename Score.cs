using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Score 
{
    public static int score = 0;
    private const int maxScores = 5;

    public static void SaveHighScore()
    {
        int[] highScores = GetHighScores();
        highScores = highScores.Append(score).OrderByDescending(s => s).Take(maxScores).ToArray();

        for(int i = 0; i < highScores.Length; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
        }
        PlayerPrefs.Save();
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore0", 0);
    }

    public static int[] GetHighScores()
    {
        int[] highScores = new int[maxScores];
        for(int i = 0; i < maxScores; i++)
        {
            highScores[i] = PlayerPrefs.GetInt("HighScore" + i, 0);
        }
        return highScores;
    }
}
