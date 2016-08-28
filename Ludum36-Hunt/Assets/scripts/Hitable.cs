using UnityEngine;
using System.Collections;

public class Hitable : MonoBehaviour {

	public Transform stickWeapon;

	void OnCollisionEnter(Collision other)
	{
		Debug.Log("hitable: " + other.gameObject.name + " tag: " + other.gameObject.tag);

		if (other.gameObject.tag == "Weapon")
		{
			Debug.Log(gameObject.name + " (hitable): " + "OUCH! I got hit by " + other.gameObject.name);
			other.gameObject.transform.SetParent(stickWeapon);
		}
	}
}
