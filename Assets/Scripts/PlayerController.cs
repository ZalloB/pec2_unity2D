using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
    public float jumpDistance = 350f;
    public float jumpDistanceMax = 100f;
    public bool starPower;

    public AudioClip jump;
    public AudioClip kick;

    private bool facingRight = false;
    private bool isGrounded = true;


    private SpriteRenderer rend;
	public new Rigidbody2D rigidbody2D;
	private Animator anim;

    public GameObject respawn;

	void Start()
	{
        rend = GetComponent<SpriteRenderer>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
        starPower = false;
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
            SoundManager.instance.RandomizeSfx(jump);
            rigidbody2D.AddForce(Vector2.up * jumpDistance );
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

        if ("enemy".Equals(collision.gameObject.tag) && !isGrounded) {
            SoundManager.instance.RandomizeSfx(kick);
            Destroy(collision.gameObject);
            GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("SetScore", ScoreManager.enemyPoints);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ("enemy".Equals(collision.gameObject.tag) && isGrounded && !starPower)
        {
            Hit(); 
            Damage();
        }
        else if("enemy".Equals(collision.gameObject.tag) && isGrounded && starPower)
        {
            SoundManager.instance.RandomizeSfx(kick);
            Destroy(collision.gameObject);
            GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("SetScore", ScoreManager.enemyPoints);
        }
    }



    void Hit() {

        rigidbody2D.AddForce(Vector2.up * (jumpDistanceMax));
        if(Random.value <= 0.5f)
            rigidbody2D.AddForce(Vector2.right * (jumpDistanceMax));
        else
            rigidbody2D.AddForce(Vector2.left * (jumpDistanceMax));

        isGrounded = false;

    }

    void Damage() {
        GameObject.Find("Player").GetComponent<PlayerHealth>().Damage(starPower, respawn);
    }
}
