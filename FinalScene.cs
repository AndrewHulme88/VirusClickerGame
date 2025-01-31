using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [SerializeField] GameObject particles;
    [SerializeField] GameObject cpu;
    [SerializeField] GameObject virus;
    [SerializeField] GameObject backsground;
    [SerializeField] float particleSpawnTime = 5f;

    void Start()
    {
        StartCoroutine("SpawnParticles");
    }

    IEnumerator SpawnParticles()
    {
        yield return new WaitForSeconds(particleSpawnTime);
        particles.SetActive(true);
        cpu.SetActive(false);
        virus.SetActive(false);
        backsground.SetActive(false);
    }
}
