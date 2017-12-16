using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelManager : MonoBehaviour
{

    public Sprite[] numbers;

    #region life numbers
    public Image unit, ten;
    #endregion

    #region Money numbers
    public Image unitM, tenM;
    #endregion

    public Text actualScore;

    public GameObject pauseMenu;

    public const string scoreText = "Score: ";

    // Use this for initialization
    void Start()
    {
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().playerScore = 0;

        //set up score and life ui

    }

    // Update is called once per frame
    void Update()
    {
        CheckPauseGame();
    }

    void SetLifeUI()
    {
        int actualHealth = GameObject.Find("Player").GetComponent<PlayerHealth>().health;
        if (actualHealth >= 0)
        unit.sprite = numbers[actualHealth];
    }

    void SetScore(int number) {
        Debug.Log(number);
        int score =  GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().playerScore + number;
        GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().playerScore = score;

        actualScore.text = scoreText + score; 
    }

    void CheckPauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.SetActive (true);
            Time.timeScale = 0;
        }
    }
}
