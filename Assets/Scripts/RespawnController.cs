using UnityEngine;

public class RespawnController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ("Player".Equals(collision.gameObject.tag))
        {
            collision.gameObject.GetComponent<PlayerController>().respawn = this.gameObject;
            
        }
    }
}
