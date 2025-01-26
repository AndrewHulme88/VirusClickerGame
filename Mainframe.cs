using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainframe : MonoBehaviour
{
    [SerializeField] GameObject hitParticles;
    [SerializeField] AudioClip damageSound;

    private Animator anim;
    private AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageSound != null)
        {
            audioSource.PlayOneShot(damageSound);
        }

        anim.SetTrigger("hit");   
        CreateHitParticles();
    }

    private void CreateHitParticles()
    {
        GameObject newParticles = Instantiate(hitParticles, transform.position, Quaternion.identity);
        Destroy(newParticles, 2f);
    }
}
