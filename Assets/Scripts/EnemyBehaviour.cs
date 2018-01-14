using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public float maxSpeed = 10f;
    public float move = 1f;

    private bool facingRight = false;

    public Rigidbody2D body;
    private SpriteRenderer rend;
    //private new Rigidbody2D rigidbody2D;

    public Transform leftEdge, rightEdge;
    

    void Start()
    {
        rend = body.GetComponent<SpriteRenderer>();
        //rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }



    void FixedUpdate() {

        
         if (!facingRight)
            move = 1f;
         else
            move = -1f;
        
        body.MovePosition(body.position + Vector2.left * move * Time.deltaTime);

        RaycastHit2D hitLeft = Physics2D.Raycast(leftEdge.position, Vector2.down, 0.5f);
        RaycastHit2D hitRight = Physics2D.Raycast(rightEdge.position, Vector2.down, 0.5f);


        if ((hitLeft.collider == null ) && !facingRight) 
            changeDirection();
        

        if ((hitRight.collider == null) && facingRight) 
            changeDirection();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Col " +collision.gameObject.tag);
        if ("enemy".Equals(collision.gameObject.tag) || "item".Equals(collision.gameObject.tag))
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
