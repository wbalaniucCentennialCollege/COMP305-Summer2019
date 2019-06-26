using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float jumpForce = 750.0f;

    // PRIVATE VARIABLES
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Fixed update is called once per frame
    // Used for physics-related calculations
    void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;
        float horiz = Input.GetAxis("Horizontal");

        if(isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        // Check direction of the player
        if(horiz < 0 && isFacingRight)
        {
            Flip();
        }
        else if(horiz > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector2 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
}
