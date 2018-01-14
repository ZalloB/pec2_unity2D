using UnityEngine;

public class BoxManager : MonoBehaviour {

    public AudioClip brokeBox;
    public AudioClip jump;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if ("Player".Equals(collision.gameObject.tag))
        {
            if (collision.gameObject.GetComponent<PlayerHealth>().powerUp || collision.gameObject.GetComponent<PlayerController>().starPower)
            {
                SoundManager.instance.RandomizeSfx(brokeBox);
                Destroy(this.gameObject);
                collision.gameObject.GetComponent<PlayerController>().rigidbody2D.AddForce(Vector2.down * (300f));
            }
        }
    }
}
