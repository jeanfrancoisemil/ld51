using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public string groundTag;

    public float speed;
    public float jumpForce;
    public float jumpCancelGravity;
    public float coyoteTime;
    private float offGroundTimer = 0f;
    public float jumpBufferTime;
    private float jumpBufferTimer = 0f;
    private bool jumpBuffered;

    private bool grounded;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = transform.Find("GFX").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            sr.flipX = horizontalInput < 0;
        }

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

        if (!Input.GetButton("Jump") && rb.velocity.y > 0)
        {
            //rb.velocity = Vector2.right * rb.velocity.x;
            rb.AddForce(Vector2.down * jumpCancelGravity);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBuffered = true;
            jumpBufferTimer = 0f;
        }
        if (jumpBuffered && offGroundTimer < coyoteTime)
        {
            //offGroundTimer = coyoteTime;
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
            bool floor = false;
            for (int i = 0; i<col.contactCount; i++)
            {
                floor = floor || (Vector2.Dot(col.GetContact(i).normal, Vector2.up) >= 0.5);
            }
            if (floor)
            {
                grounded = true;
                offGroundTimer = 0f;
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.tag == groundTag)
        {
            bool floor = false;
            for (int i = 0; i<col.contactCount; i++)
            {
                floor = floor || (Vector2.Dot(col.GetContact(i).normal, Vector2.up) >= 0.5);
            }
            if (floor)
            {
                grounded = true;
                offGroundTimer = 0f;
            }else {
                grounded = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == groundTag)
        {
            grounded = false;
        }
    }

}