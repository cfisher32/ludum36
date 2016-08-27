using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{

	public float throwSpeed = 100.0f;
	public Vector3 throwVector = new Vector3(0,1,1);

	Rigidbody myRB;

	void Awake()
	{
		throwVector = transform.forward;
		myRB = GetComponent<Rigidbody>();

		//myRB.AddForce(throwVector * throwSpeed);
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log(other.gameObject.name);
	}
}
