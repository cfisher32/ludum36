using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject[] spawnPoints;

	public void spawnEnemy()
	{
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);
		spawnPoints[spawnPointIndex].GetComponent<SpawnController>().Spawn();


	}
}
