using UnityEngine;

public class FireBallController : MonoBehaviour {

    public Rigidbody2D rigidbody2d;
    public GameObject explosionObject;
    public Vector2 velocity;


    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 10);
        rigidbody2d = GetComponent<Rigidbody2D>();
        velocity = rigidbody2d.velocity;

    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody2d.velocity.y < velocity.y)
            rigidbody2d.velocity = velocity;
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        rigidbody2d.velocity = new Vector2(velocity.x, -velocity.y);
        
        if (col.collider.tag == "enemy")
        {
            Destroy(col.gameObject);
            GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("SetScore", ScoreManager.enemyPoints);
            Explode();
        }

        if (col.contacts.Length > 0)
        {
            if (col.contacts[0].normal.x != 0)
            {
                Explode();
            }
        }

       

    }

    void Explode()
    {
        Instantiate(explosionObject, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
