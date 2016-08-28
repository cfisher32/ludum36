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

	void Awake()
	{
		_instance = this;
		DontDestroyOnLoad(this.gameObject);
	}

	void Start()
	{
		Score = 0;
	}

	public void SetScore(int value)
	{
		Score += value;
		scoreText.text = "Score: " + Score;
	}
}
