//cmf

using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public float spawnRate = 5.0f;
	public GameObject enemy;
	public bool spawnFacingRight = true;

	void Start()
	{
		InvokeRepeating("Spawn", spawnRate, spawnRate);
	}

	void Spawn()
	{
		GameObject obj = (GameObject)Instantiate(enemy, transform.position, Quaternion.identity);
		obj.GetComponent<EnemyMovement>().isMovingRight = spawnFacingRight;
	}
}
