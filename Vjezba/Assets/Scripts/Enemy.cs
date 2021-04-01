using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float agroRange;
    public float speed;
    bool chase = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance <= agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }

    }

    private void StopChasingPlayer()
    {
        rb.velocity = Vector2.zero;
    }

    private void ChasePlayer()
    {
        if (transform.position.x < player.transform.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
            sr.flipX = false;
        }
        else if (transform.position.x > player.transform.position.x)
        {
            rb.velocity = new Vector2(-speed, 0);
            sr.flipX = true;
        }
    }
       
}
