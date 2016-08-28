using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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

	public int Score { get; set; }
	public bool playerIsDead { get; set; }
	public Text scoreText;
	public Text timerText;
	public float roundLeft = 5.0f;
	public bool roundOver = false;

	void Awake()
	{
		_instance = this;
		DontDestroyOnLoad(this.gameObject);
	}

	void Start()
	{
		Score = 0;
	}

	void Update()
	{
		setTimer();
	}

	public void setScore(int value)
	{
		Score += value;
		scoreText.text = "Score: " + Score;
		Debug.Log("SCORE: " + Score);
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
			}
		}
	}
}
