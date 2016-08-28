using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public float spawnRate = 2.0f;
	public float spawnDelay = 0f;
	public GameObject enemy;

	void Update()
	{
		if (Time.time > spawnDelay)
		{
			spawnDelay = Time.time + spawnRate;

			Instantiate(enemy, transform.position, Quaternion.identity);
		}
	}
}
