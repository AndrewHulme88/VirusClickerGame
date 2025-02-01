using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] float typingSpeed = 0.2f;
    [SerializeField] MainMenu mainMenu;
    [SerializeField] AudioClip clickSound;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public GameObject continueButton;

    private int index;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        continueButton.SetActive(true);
    }

    public void NextSentence()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            mainMenu.GoToNextScene();
        }
    }
}
