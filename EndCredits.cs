using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 50f;
    [SerializeField] float duration = 15f;

    private void Start()
    {
        Invoke("LoadMainMenu", duration);
    }

    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed *  Time.deltaTime);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("TitleMenu");
    }
}
