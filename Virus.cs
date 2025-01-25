using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int infectionScore = 1;
    [SerializeField] int bugsCaughtscore = 1;
    [SerializeField] int health = 1;
    [SerializeField] GameObject hitParticles;
    [SerializeField] float deathDelay = 1f;

    [Header("Splitter")]
    [SerializeField] bool isSplitter = false;
    [SerializeField] GameObject splitVirusPrefab;
    [SerializeField] int splitCount = 2;
    [SerializeField] float splitOffest = 1f;

    private Rigidbody2D rb;
    private Animator animator;
    private Mainframe mainframe;
    private GameManager gameManager;
    private ScreenShake screenShake;

    private bool isDying = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mainframe = FindObjectOfType<Mainframe>();
        gameManager = FindObjectOfType<GameManager>();
        screenShake = FindObjectOfType<ScreenShake>();
    }

    void Update()
    {
        if (isDying) return;
        Vector3 direction = (mainframe.transform.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void OnMouseDown()
    {
        if (isDying) return;

        Damage();
    }

    private void Damage()
    {
        animator.SetTrigger("hit");
        health--;
        if(health <= 0)
        {
            CreateHitParticles();
            isDying = true;

            if(isSplitter)
            {
                Split();
            }
            gameManager.AddBugsCaughtScore(bugsCaughtscore);
            DisableVirus();
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    private void DisableVirus()
    {
        GetComponent<Collider2D>().enabled = false;
        rb.velocity = Vector2.zero;
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(deathDelay);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mainframe"))
        {
            gameManager.AddInfectedScore(infectionScore);
            screenShake.TriggerShake();
            Destroy(this.gameObject);
        }
    }

    private void CreateHitParticles()
    {
        GameObject newParticles = Instantiate(hitParticles, transform.position, Quaternion.identity);
        Destroy(newParticles, 2f);
    }

    private void Split()
    {
        for(int i = 0; i < splitCount; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-splitOffest, splitOffest), Random.Range(-splitOffest, splitOffest), 0);
            Instantiate(splitVirusPrefab, transform.position + offset, Quaternion.identity);
        }
    }
}
