//cmf

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Text scoreText;
	public Text timerText;
	public Text gameMessage;
	public Canvas hud;

	public int score { get; set; }
	public bool playerIsDead { get; set; }
	public float roundLeft = 5.0f;
	public bool roundOver = false;
	public bool isGameOver = false;
	public float restartTimer;
	public float restartTimerDelay = 5.0f;

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
		if (!isGameOver)
		{
			setTimer();
		}
		else
		{
			restartTimer += Time.deltaTime;
			if(restartTimer >= restartTimerDelay)
			{
				restartGame();
			}
		}
	}

	public void setScore(int value)
	{
		if (!isGameOver)
		{
			score += value;
			scoreText.text = "Score: " + score;
			Debug.Log("SCORE: " + score);
		}
	}

	public void setTimer()
	{
		if (!roundOver)
		{
			roundLeft -= Time.deltaTime;
			timerText.text = "Time Left: " + roundLeft;

			if (roundLeft <= 0)
			{
				roundComplete();
			}
		}
	}

	void roundComplete()
	{
		roundOver = true;
		timerText.text = "Round Complete";

		Debug.Log("Round Over");
		checkGameStatus();
	}

	public void checkGameStatus()
	{
		isGameOver = true;
		hud.GetComponent<Animator>().SetBool("isGameOver", isGameOver); //anim for HUDCanvas

		if (score >= scoreRequired)
		{
			Debug.Log("You win!");
			gameMessage.text = "You Win!";
		}
		else
		{
			Debug.Log("Your tribe is dead. You lose.");
			gameMessage.text = "You lose.";
		}
	}

	public void restartGame()
	{
		SceneManager.LoadScene(Application.loadedLevel);
	}
}
