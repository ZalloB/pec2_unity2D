using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

	public float maxSpeed = 10f;
    public float jumpDistance = 350f;
    private bool facingRight = true;
    private bool isGrounded = true;

	private new Rigidbody2D rigidbody2D;
	private Animator anim;

	void Start()
	{
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

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

        if(isGrounded)
            anim.SetBool("isJumping", false);
        else
            anim.SetBool("isJumping", true);

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody2D.AddForce(Vector2.up * jumpDistance);
            isGrounded = false;
        }
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ("floor".Equals(collision.gameObject.tag) || "item".Equals(collision.gameObject.tag))
        {
            isGrounded = true;
        }
    }
}
