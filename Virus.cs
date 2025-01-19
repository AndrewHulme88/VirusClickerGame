using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int infectionScore = 1;
    [SerializeField] int bugsCaughtscore = 1;
    [SerializeField] int health = 1;

    private Rigidbody2D rb;
    private Mainframe mainframe;
    private GameManager gameManager;
    private ScreenShake screenShake;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainframe = FindObjectOfType<Mainframe>();
        gameManager = FindObjectOfType<GameManager>();
        screenShake = FindObjectOfType<ScreenShake>();
    }

    void Update()
    {
        Vector3 direction = (mainframe.transform.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void OnMouseDown()
    {
        Damage();
    }

    private void Damage()
    {
        health--;
        if(health <= 0)
        {
            gameManager.AddBugsCaughtScore(bugsCaughtscore);
            Destroy(this.gameObject);
        }
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
}
