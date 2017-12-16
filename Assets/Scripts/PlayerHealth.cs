using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int health;
    private int maxHealth = 3;

	// Use this for initialization
	void Start () {
        health = maxHealth;        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Damage() {
        health --;

        GameObject.Find("GameManager").GetComponent<GameLevelManager>().SendMessage("SetLifeUI");
    }
}
