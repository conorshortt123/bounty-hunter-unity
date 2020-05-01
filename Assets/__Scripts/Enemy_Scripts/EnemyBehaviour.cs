using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpInterval;
    [SerializeField] private bool menu = false;
    private float timer;
    private Vector2 currVelocity;
    Rigidbody2D rb;
    BoxCollider2D bc;
    public GameObject player;

    //[RequireComponent(typeof(Rigidbody2D))]
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!menu)  
        {
            jumpForce = Random.Range(10.0f, 50.0f);
            speed = Random.Range(1.0f, 5.0f);
            jumpInterval = Random.Range(1.0f, 5.0f);
        }
        else
        {
            jumpForce = Random.Range(50.0f, 80.0f);
            speed = Random.Range(1.0f, 5.0f);
            jumpInterval = Random.Range(0.5f, 2.0f);
        }
        //bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x > -20.0f)
        {
            rb.AddForce(Vector2.left * speed);
        }

        // Make the tumbleweed jump every x amount of seconds (default 5).
        if (timer >= jumpInterval)
        {
            for (int i = 0; i < 10; i++)
            {
                Jump();
            }
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision");
        Destroy(player);
    }*/
}
