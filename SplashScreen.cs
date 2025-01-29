using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] float splashDuration = 3f;
        
    void Start()
    {   
        Invoke("LoadNextScene", splashDuration);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("TitleMenu");
    }
}
