//cmf

using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
	//mass, drag per weapon
	public float torque;
	public float spinningSpeed;

	//audio
	public AudioClip thrownSfx;
	public AudioClip thudSfx;

	Rigidbody myRB;
	AudioSource myAudio;

	void Awake()
	{
		myRB = GetComponent<Rigidbody>();
		myAudio = GetComponent<AudioSource>();

		myAudio.PlayOneShot(thrownSfx, 0.6f);
		myRB.AddRelativeTorque(Vector3.right * spinningSpeed);
	}


	void OnCollisionEnter(Collision other)
	{
		//Debug.Log(gameObject.name + ": " + other.gameObject.name + " tag: " + other.gameObject.tag);
		if(other.gameObject.tag == "Hitable")
		{
			myRB.isKinematic = true;
			myRB.useGravity = false;

			myAudio.PlayOneShot(thudSfx, 0.5f);

			gameObject.transform.SetParent(other.gameObject.transform);
		}
	}
}
