using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainframe : MonoBehaviour
{
    [SerializeField] GameObject hitParticles;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("hit");   
        CreateHitParticles();
    }

    private void CreateHitParticles()
    {
        GameObject newParticles = Instantiate(hitParticles, transform.position, Quaternion.identity);
        Destroy(newParticles, 2f);
    }
}
