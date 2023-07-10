using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigid = default;
    private Animator animator = default;
    private AudioSource playerAudio = default;

    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        GFunc.Assert(playerRigid != null);
        GFunc.Assert(animator != null);
        GFunc.Assert(playerAudio != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) { return; }

        if (Input.GetMouseButtonDown(0) && jumpCount == 0 && jumpCount < 2)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector3.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        }
        else if(Input.GetMouseButtonDown(0) && jumpCount == 1 && jumpCount < 2)
        {
            playerRigid.velocity = Vector3.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            animator.SetTrigger("IsDoubleJump");
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonDown(0) && playerRigid.velocity.y > 0)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }

        animator.SetBool("IsGround", isGrounded);
    }

    private void Die()
    {
        animator.SetTrigger("IsDie");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigid.velocity = Vector2.zero;
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Dead") && isDead == false)
        {
            Die();
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    isGrounded = false;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
