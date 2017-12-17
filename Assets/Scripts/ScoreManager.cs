using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance = null;
    public int playerScore;
    public float time;
    public int money;
    public const int enemyPoints = 200;
    public const int coinPoints = 300;
    public const int starPoints = 800;
    public const int mushroomPoints = 400;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

}