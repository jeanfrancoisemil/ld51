using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    public string groundTag;

    public float speed;
    public float jumpForce;
    public float coyoteTime;
    private float offGroundTimer = 0f;
    public float jumpBufferTime;
    private float jumpBufferTimer = 0f;
    private bool jumpBuffered;

    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (!grounded)
        {
            offGroundTimer += Time.deltaTime;
        }

        if (jumpBuffered)
        {
            jumpBufferTimer += Time.deltaTime;
            if (jumpBufferTimer > jumpBufferTime)
            {
                jumpBuffered = false;
                jumpBufferTimer = 0f;
            }
        }

        rb.velocity = Vector2.right * horizontalInput * speed + Vector2.up * rb.velocity.y;
        if (Input.GetButtonDown("Jump"))
            jumpBuffered = true;
        if (jumpBuffered && offGroundTimer < coyoteTime)
        {
            jumpBuffered = false;
            jumpBufferTimer = 0f;
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.right * rb.velocity.x + Vector2.up * jumpForce;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == groundTag)
        {
            grounded = true;
            offGroundTimer = 0f;
        }
    }

    // void OnCollisionStay2D(Collision2D col)
    // {

    // }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == groundTag)
        {
            grounded = false;
        }
    }

}