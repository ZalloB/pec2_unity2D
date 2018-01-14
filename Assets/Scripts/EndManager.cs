using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour {

    public Text Score;
    public Text money;
    public Text leftTime;

	// Use this for initialization
	void Start () {
        if (ScoreManager.instance != null)
        {
            Score.text = "Score: " + ScoreManager.instance.playerScore;
            money.text = "X " + ScoreManager.instance.money;
            leftTime.text = "Time left:  " + ScoreManager.instance.time.ToString("#");
        }
	}
	
}
