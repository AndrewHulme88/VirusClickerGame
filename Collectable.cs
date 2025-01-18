using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Mainframe mainframe;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainframe = FindObjectOfType<Mainframe>();
    }

    void Update()
    {
        Vector3 direction = (mainframe.transform.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void OnMouseDown()
    {
        Debug.Log("Click");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Mainframe"))
        {
            Destroy(this.gameObject);
        }
    }
}
