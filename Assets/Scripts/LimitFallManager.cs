using UnityEngine;

public class LimitFallManager : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if(collision.tag == "Player") {
            GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("GameOver");
        }
    }
}
