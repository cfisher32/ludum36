//cmf

using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public float spawnRate = 5.0f;
	public bool spawnFacingRight = true;

	void Start()
	{
		//InvokeRepeating("Spawn", spawnRate, spawnRate);
	}

	public void Spawn(GameObject enemy)
	{
		GameObject obj = (GameObject)Instantiate(enemy, transform.position, Quaternion.identity);
		obj.GetComponent<EnemyMovement>().isMovingRight = spawnFacingRight;
	}
}
