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
	public AudioClip winSfx;
	public AudioClip loseSfx;

	public int score { get; set; }
	public bool playerIsDead { get; set; }
	public float roundLeft = 5.0f;
	public bool roundOver = false;
	public bool isGameOver = false;
	public float restartTimer;
	public float restartTimerDelay = 5.0f;
	public float spawnTimer;
	public float spawnTimerDelay = 2.0f;

	public int scoreRequired = 5;
	public int enemyCountMax = 10;
	public int currentEnemyCount = 0;
	public float spawnRate = 2.0f;

	AudioSource myAudio;
	public SpawnManager spawnManager;

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
		myAudio = GetComponent<AudioSource>();
		//spawner = spawnManager.GetComponent<SpawnManager>();

		InvokeRepeating("spawnEnemy", spawnRate, spawnRate); //set so it only triggers another spawn

		score = 0;
	}

	void Update()
	{
		if (!isGameOver)
		{
			//if (Time.time > spawnTimer)
			//{
			//	spawnTimer = Time.time + spawnTimerDelay;
			//	spawnEnemy();
			//}

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

	public void spawnEnemy()
	{
		if(!isGameOver && currentEnemyCount < enemyCountMax)
		{
			spawnManager.spawnEnemy();
			currentEnemyCount++;
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
		Debug.Log("Round Over");

		roundOver = true;
		timerText.text = "Round Complete";
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
			myAudio.PlayOneShot(winSfx);
		}
		else
		{
			Debug.Log("Your tribe is dead. You lose.");
			gameMessage.text = "You lose.";
			myAudio.PlayOneShot(loseSfx);
		}
	}

	public void restartGame()
	{
		SceneManager.LoadScene(0);
	}
}
