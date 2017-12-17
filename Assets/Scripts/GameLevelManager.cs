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
    public Text actualTime;

    public GameObject pauseMenu;

    public const string scoreText = "Score: ";
    public const string timeText = "Time\n";

    public AudioClip pause;
    public AudioClip gameOver;
    public AudioClip win;

    bool isFinish;
    // Use this for initialization
    void Start()
    {
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().playerScore = 0;
        GameObject.Find("ScoreManager").GetComponent<ScoreManager>().time = 300;
        isFinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPauseGame();
    }

    void FixedUpdate()
    {
        if(!isFinish){
            RemoveTime();
        }
        
    }

    void SetLifeUI()
    {
        int actualHealth = GameObject.Find("Player").GetComponent<PlayerHealth>().health;
        if (actualHealth >= 0)
        unit.sprite = numbers[actualHealth];
    }

    void SetScore(int number) {
        
        int score =  GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().playerScore + number;
        GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().playerScore = score;

        actualScore.text = scoreText + score; 
    }

    void SetUIMoney()
    {
        GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().money += 1;
        int value = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().money;
        if(value > 10)
        {
            tenM.sprite = numbers[value / 10];
            unitM.sprite = numbers[value % 10];
        }
        else
        {
            unitM.sprite = numbers[value];
        }
    }

    void CheckPauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            SoundManager.instance.RandomizeSfx(pause);
            SoundManager.instance.musicSource.Pause();
            pauseMenu.SetActive (true);
            Time.timeScale = 0;
        }
    }

    void RemoveTime()
    {
        float time = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().time -= Time.deltaTime;
        if(time <0)
        {
            GameOver();
        }
        else {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().time-= Time.deltaTime;
      
            actualTime.text = timeText + time.ToString("#");
        }
       
    }

    void GameOver() {
        SoundManager.instance.musicSource.Pause();
        SoundManager.instance.RandomizeSfx(gameOver);
        UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }

    void Win()
    {
        SoundManager.instance.musicSource.Pause();
        SoundManager.instance.RandomizeSfx(win);

        // count score
        StartCoroutine("loadScore");
    }

    IEnumerator loadScore()
    {
        isFinish = true;
        for (int i = 0; i < GameObject.Find("ScoreManager").GetComponent<ScoreManager>().time; i++)
        {
            SetScore(1);
        }
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene("End");
    }
}
