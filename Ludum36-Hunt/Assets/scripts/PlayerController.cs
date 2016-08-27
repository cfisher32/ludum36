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

	void Start()
	{
		//targetPlane = new Plane(Vector3.up, Vector3.zero);
		//targetPlane = new Plane(Vector3.up, transform.position);
	}
	

	void Update()
	{
		//createTargetPlane();
		if (Input.GetAxis("Fire1") > 0)
		{
			throwWeapon();
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//if (Physics.Raycast(ray))
			//{
			//	targetPoint = ray.GetPoint(100.0f);
			//	throwWeapon();
			//	//Debug.DrawRay(playerThrowSpot.position, targetPoint, Color.blue);
			//	Debug.Log(ray.GetPoint(100.0f).ToString());
			//}
		}

		//rotateThrowingArm();
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
				//Debug.DrawLine(transform.position, hit.point);
				Debug.DrawRay(playerThrowSpot.position, hit.point, Color.blue);

				GameObject bullet = (GameObject)Instantiate(projectile, playerThrowSpot.position, Quaternion.identity);
				//playerThrowSpot.LookAt(hit.point);
				bullet.transform.LookAt(hit.point);

				//Vector3 throwVector = new Vector3(0, 1, 1);
				Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
				//bulletRB.velocity = bullet.transform.forward * 10;
				bulletRB.AddForce((hit.point - bullet.transform.position) * throwSpeed);

				Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

				//GameObject ammo = (GameObject)Instantiate(projectile, playerThrowSpot.position, Quaternion.identity);
			}
		}
	}
}
