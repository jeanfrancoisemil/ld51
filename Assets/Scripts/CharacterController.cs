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
//    public float jumpBufferTime;
//    private bool jumpBuffered;
//    private float jumpBufferedTimer = 0f;

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

        rb.velocity = Vector2.right * horizontalInput * speed + Vector2.up * rb.velocity.y;
        if (Input.GetButtonDown("Jump") && offGroundTimer < coyoteTime)
        {
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

    void OnCollisionStay2D(Collision2D col)
    {

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == groundTag)
        {
            grounded = false;
        }
    }

}
