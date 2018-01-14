using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public AudioClip downPower;
    public int health;
    private int maxHealth = 3;
    public bool powerUp;

	// Use this for initialization
	void Start () {
        health = maxHealth;
        powerUp = false;
        
    }
	

    public void Damage(bool starPower, GameObject respawn) {
        health --;
        if (!powerUp && !starPower) { 
            GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("SetLifeUI");
            if (health == 0) {
                GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("GameOver");
            }
            else
            {
                this.transform.position = new Vector3(respawn.transform.position.x, this.transform.position.y, transform.position.z);
            }
        }
        else if(!starPower)
        {
            SoundManager.instance.RandomizeSfx(downPower);
            powerUp = false;
        }
    }
}
