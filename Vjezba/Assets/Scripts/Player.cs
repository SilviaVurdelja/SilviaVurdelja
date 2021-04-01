using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject projectile;
    private bool isRight = true;

    private Vector2 moveDirection;
    private void ProcessInputs ()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && (moveDirection.x != 0 || moveDirection.y != 0))
        {
            Debug.Log(moveDirection.x + " " + moveDirection.y);
        }
        moveDirection = new Vector2(moveX, moveY); 
    }

    private void Animate()
    {
        anim.SetFloat("AnimMoveX", moveDirection.x);
        anim.SetFloat("AnimMoveY", moveDirection.y);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
        
        if (Input.GetKeyDown("f"))
        {
            var obj = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
            obj.GetComponent<Projectile>().isRight = isRight;
            if (isRight)
            {
                obj.transform.position = new Vector3(transform.position.x + 1.17f, transform.position.y, 0);
            }
            else
            {
                obj.transform.position = new Vector3(transform.position.x + 1.17f, transform.position.y, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
}

