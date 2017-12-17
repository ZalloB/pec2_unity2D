using System.Collections;
using System.Collections.Generic;
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
	

    public void Damage(bool starPower) {
        health --;
        if (!powerUp && !starPower) { 
            GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("SetLifeUI");
            GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("GameOver");
        }
        else if(!starPower)
        {
            SoundManager.instance.RandomizeSfx(downPower);
            powerUp = false;
        }
    }
}
