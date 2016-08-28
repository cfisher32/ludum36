//cmf

using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	//move pattern, random
	void Update()
	{
		Mover();
		//ScalePingPong();
	}

	/*
	Direction to move as a Vector 
		x: (1,0,0) = right		(-1,0,0) = left
		y: (0,1,0) = up			(0,-1,0) = down
		z: (0,0,1) = zoom out	(0,0,-1) = zoom in
	*/
	public Vector3 direction = Vector3.zero;
	public float speed = 2.0f;                          //movement speed (units per second)

	// Update is called once per frame
	void Mover()
	{
		transform.position += direction * speed * Time.deltaTime;
	}

	public float smallScale = 1.0f;     //smallest scale of object
	public float largeScale = 4.0f;     //largest scale of object

	void ScalePingPong()
	{
		//throb scale
		float scaleFactor = smallScale + Mathf.PingPong(Time.time, 1.0f);

		//apply throb
		transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
	}
}
