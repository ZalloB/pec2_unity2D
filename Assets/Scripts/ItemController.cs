using System.Collections;
using UnityEngine;

public class ItemController : MonoBehaviour {

    public AudioClip star;
    public string type;
    public Rigidbody2D body;
    public float move = 1f;

    void Update()
    {
        if (!type.Equals("money"))
            body.MovePosition(body.position + Vector2.right * move * Time.deltaTime);
        else
            StartCoroutine("DestroyMoney");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if ("Player".Equals(collision.gameObject.tag))
        {
            if (type.Equals("mushroom"))
            {
                collision.gameObject.GetComponent<PlayerHealth>().powerUp = true;
                GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("SetScore", ScoreManager.mushroomPoints);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerController>().starPower = true;
                GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("SetScore", ScoreManager.starPoints);
            }
           


            SoundManager.instance.RandomizeSfx(star);
            Destroy(this.gameObject);
            
        }

    }

    IEnumerator DestroyMoney() {
        
        yield return new WaitForSeconds(1);
        GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("SetUIMoney");
        GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("SetScore", ScoreManager.coinPoints);
        Destroy(this.gameObject);
    }
}
