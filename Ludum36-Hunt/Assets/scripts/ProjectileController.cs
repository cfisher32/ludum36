//cmf

using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
	//mass, drag per weapon

	Rigidbody myRB;

	void Awake()
	{
		myRB = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log(gameObject.name + ": " + other.gameObject.name + " tag: " + other.gameObject.tag);
		if(other.gameObject.tag == "Hitable")
		{
			myRB.isKinematic = true;
			myRB.useGravity = false;

			gameObject.transform.SetParent(other.gameObject.transform);
		}
	}
}
