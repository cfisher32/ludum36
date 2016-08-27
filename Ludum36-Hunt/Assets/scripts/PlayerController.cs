//cmf

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//throwing
	public float throwRate = 0.5f;
	public float throwRateDelay = 0f;
	public GameObject projectile;
	public Transform playerThrowSpot;
	public Transform playerThrowingArm;
	public float throwSpeed;
	public Plane targetPlane;
	public Vector3 targetPoint;
	public Vector3 throwVector = new Vector3(0, 1, 1);
	public LayerMask throwLayerMask;

	void Update()
	{
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

			Ray targetRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(targetRay, out hit, 100.0f, throwLayerMask))
			{
				Debug.DrawRay(playerThrowSpot.position, hit.point, Color.blue);

				GameObject bullet = (GameObject)Instantiate(projectile, playerThrowSpot.position, Quaternion.identity);
				bullet.transform.LookAt(hit.point);

				Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
				bulletRB.AddForce((hit.point - bullet.transform.position) * throwSpeed);

				Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
			}
		}
	}
}
