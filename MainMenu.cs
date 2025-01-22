using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void TitleMenu()
    {
        SceneManager.LoadScene("TitleMenu");
    }
}
