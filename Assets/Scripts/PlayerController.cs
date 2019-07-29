using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float jumpForce = 750.0f;
    [SerializeField]
    private LayerMask rayCastLM;

    // PRIVATE VARIABLES
    private Rigidbody2D rBody;
    private Animator anim;
    private AudioSource aSrc;
    private bool isGrounded = false;
    private bool isFacingRight = true;
    private Vector2 rayCastOrigin;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        //isDead = false;
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aSrc = GetComponent<AudioSource>();
    }

    // Fixed update is called once per frame
    // Used for physics-related calculations
    void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;
        float horiz = Input.GetAxis("Horizontal");

        // CheckIfGround();

        if(isGrounded && Input.GetAxis("Jump") > 0)
        {
            aSrc.Play();
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

        // Update Animator Information
        anim.SetFloat("xSpeed", Mathf.Abs(horiz));
        anim.SetFloat("ySpeed", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    /*
    private void CheckIfGround()
    {
        
        rayCastOrigin = new Vector2(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().sprite.bounds.size.y);
        RaycastHit2D hit = Physics2D.Raycast(rayCastOrigin, Vector2.down, 0.1f, rayCastLM);
        

        RaycastHit2D hit = Physics2D.CircleCast(transform.GetChild(0).transform.position, 0.1f, Vector2.down, 0.1f, rayCastLM);

        if(hit)
        {
            isGrounded = true;
            // Invoke("ResetGround", 0.1f);
            Debug.Log("I hit the ground");
        }
    }
    */

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
    
    public void Death()
    {
        isDead = true;
        anim.SetBool("isDead", true);
    }
    

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
