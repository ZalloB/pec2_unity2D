using UnityEngine;

public class ItemManager : MonoBehaviour {

    public GameObject mushroom;
    public GameObject star;
    public GameObject money;
    public AudioClip powerAppears;
    public AudioClip moneySound;
    public Sprite boxUsed;
    public bool isUsed;

    // Use this for initialization
    void Start () {
        isUsed = false;
	}


    void OnTriggerEnter2D(Collider2D collision)
    {
        if ("Player".Equals(collision.gameObject.tag) && !isUsed)
        {
            
            if (Random.Range(1, 100) >= 50)
            {
                SoundManager.instance.RandomizeSfx(powerAppears);
                Instantiate(mushroom, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            }
            else
            {
                SoundManager.instance.RandomizeSfx(moneySound);
                Instantiate(money, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            }
           
            this.gameObject.GetComponent<SpriteRenderer>().sprite = boxUsed;
            isUsed = true;

        }
    }
}
