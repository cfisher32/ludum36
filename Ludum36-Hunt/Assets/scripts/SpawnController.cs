//cmf

using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public float spawnRate = 5.0f;
	public GameObject enemy;

	void Start()
	{
		InvokeRepeating("Spawn", spawnRate, spawnRate);
	}

	void Spawn()
	{
		Instantiate(enemy, transform.position, Quaternion.identity);
	}
}
