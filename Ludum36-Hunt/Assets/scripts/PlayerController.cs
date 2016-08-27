 using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//throwing
	public float throwRate = 0.5f;
	public float throwRateDelay = 0f;
	public GameObject projectile;
	public Transform playerThrowSpot;
	public float throwSpeed;

	void Update () {
		if (Input.GetAxis("Fire1") > 0)
		{
			throwWeapon();
		}
	}
	void throwWeapon()
	{
		if (Time.time > throwRateDelay)
		{
			throwRateDelay = Time.time + throwRate;

			GameObject ammo = (GameObject)Instantiate(projectile, playerThrowSpot.position, Quaternion.identity);
		}
	}
}
