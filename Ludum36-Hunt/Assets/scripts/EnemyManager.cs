using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject[] enemyTypes;

	public GameObject getEnemy()
	{
		int enemyIndex = Random.Range(0, enemyTypes.Length);
		return enemyTypes[enemyIndex];
	}
}
