//cmf

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int score { get; set; }
	public bool playerIsDead { get; set; }
	public Text scoreText;
	public Text timerText;
	public float roundLeft = 5.0f;
	public bool roundOver = false;

	public int scoreRequired = 5;

	private static GameManager _instance;

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject gm = new GameObject("GameManager");
				gm.AddComponent<GameManager>();
			}
			return _instance;
		}
	}

	void Awake()
	{
		_instance = this;
		//DontDestroyOnLoad(this.gameObject);
	}

	void Start()
	{
		score = 0;
	}

	void Update()
	{
		setTimer();
	}

	public void setScore(int value)
	{
		score += value;
		scoreText.text = "Score: " + score;
		Debug.Log("SCORE: " + score);
	}

	public void setTimer()
	{
		if (!roundOver)
		{
			roundLeft -= Time.deltaTime;
			timerText.text = "Time Left: " + roundLeft;

			if (roundLeft <= 0)
			{
				roundOver = true;
				timerText.text = "Round Complete";
				Debug.Log("Round Over");
				checkGameStatus();
			}
		}
	}

	public void checkGameStatus()
	{
		if(score >= scoreRequired)
		{
			Debug.Log("You win!");
		}
		else
		{
			Debug.Log("Your tribe is dead. You lose.");
		}
	}

	public void restartGame()
	{
		SceneManager.LoadScene(0);
	}
}
