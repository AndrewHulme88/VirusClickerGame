using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public GameObject continueButton;

    private int index;
    public float typingSpeed = 0.2f;

    void Start()
    {
        StartCoroutine(Type());
    }

    //private void Update()
    //{
    //    if(textDisplay.text == sentences[index])
    //    {
    //        continueButton.SetActive(true);
    //    }
    //}

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
        }
    }
}
