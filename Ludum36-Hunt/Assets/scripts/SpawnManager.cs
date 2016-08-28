using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject[] spawnPoints;

	public EnemyManager enemyManager;

	public void spawnEnemy()
	{
		GameObject enemy = enemyManager.getEnemy();
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);
		spawnPoints[spawnPointIndex].GetComponent<SpawnController>().Spawn(enemy);
	}
}
