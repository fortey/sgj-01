using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    public float StartTime = 1f;
    public bool canMove;
    bool gameEnd=false;
    public GameObject Light;

    public float moveSpeed = 6f;
    bool isFacingRight = true;
    bool isGrounded = false;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    float groundRadius = 0.2f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartTime -= Time.deltaTime;
        if (StartTime < 0&& !gameEnd) { canMove = true;
            Destroy(Light);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)&& canMove)
        {
            rb.AddForce(new Vector2(0, 400));
        }
    }

    void FixedUpdate()
    {
        Run();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (!isGrounded)
            return;
    }
    public void Run()
    {
        if (!canMove) return;
        float move = Input.GetAxis("Horizontal");


        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    public void ComeIn()
    {
        gameEnd = true;
        canMove = false;
        
    }

}
