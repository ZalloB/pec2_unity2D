using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour {

    public AudioClip brokeBox;
    public AudioClip jump;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


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
