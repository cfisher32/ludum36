using UnityEngine;
using System.Collections;

public class LifetimeGO : MonoBehaviour
{

	public float lifeTime = 5.0f;

	void Awake()
	{
		DestroyObject(gameObject, lifeTime);
	}
}
