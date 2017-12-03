using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

	public float maxSpeed = 10f;
    public float jumpDistance = 350f;
    private bool facingRight = false;
    private bool isGrounded = true;


    private SpriteRenderer rend;
	private new Rigidbody2D rigidbody2D;
	private Animator anim;

	void Start()
	{
        rend = GetComponent<SpriteRenderer>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		float move = Input.GetAxis ("Horizontal");

        if (move != 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

        if (move > 0)
            facingRight = false;
        else if (move < 0)
            facingRight = true;
        Flip();


        if (isGrounded)
            anim.SetBool("isJumping", false);
        else
            anim.SetBool("isJumping", true);

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpDistance);
            isGrounded = false;
        }
	}

	void Flip(){
		//facingRight = !facingRight;
        if (!facingRight)
            rend.flipX = false;
        else
            rend.flipX = true;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ("floor".Equals(collision.gameObject.tag) || "item".Equals(collision.gameObject.tag))
        {
            isGrounded = true;
        }
    }
}
