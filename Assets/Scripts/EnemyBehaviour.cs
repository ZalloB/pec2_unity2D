using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float maxSpeed = 10f;
    public float move = 1f;
    private bool facingRight = false;

    private SpriteRenderer rend;
    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (facingRight)
            rigidbody2D.velocity = new Vector2(move * maxSpeed * Time.deltaTime , rigidbody2D.velocity.y);
        else
            rigidbody2D.velocity = new Vector2(-move * maxSpeed * Time.deltaTime, rigidbody2D.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ("floor".Equals(collision.gameObject.tag))
            changeDirection();
 
    }

    void changeDirection()
    {
        if (!facingRight)
            rend.flipX = true;
        else
            rend.flipX = false;

        facingRight = !facingRight;
    }
}
