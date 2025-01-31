using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    [SerializeField] GameObject particles;
    [SerializeField] GameObject cpu;
    [SerializeField] GameObject virus;
    [SerializeField] GameObject background;
    [SerializeField] float particleSpawnTime = 5f;
    [SerializeField] GameObject startTransition;
    [SerializeField] GameObject endTransition;
    [SerializeField] float sceneTransitionTime = 1f;

    void Start()
    {
        endTransition.SetActive(false);
        startTransition.SetActive(true);
        StartCoroutine("SpawnParticles");
    }

    IEnumerator SpawnParticles()
    {
        yield return new WaitForSeconds(particleSpawnTime);
        particles.SetActive(true);
        cpu.SetActive(false);
        virus.SetActive(false);
        background.SetActive(false);
        StartCoroutine(TransitionToNextScene());
    }

    IEnumerator TransitionToNextScene()
    {
        endTransition.SetActive(true);
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene("EndCredits");
    }
}
