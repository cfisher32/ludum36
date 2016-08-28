//cmf

using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Color hitColor = Color.red;
	public bool isDead = false;
	public int value = 1;

	Renderer myRend;
	Color orgColor;

	void Start()
	{
		myRend = GetComponent<Renderer>();
		orgColor = myRend.material.GetColor("_Color");
	}

	void OnCollisionEnter(Collision other)
	{
		//Debug.Log("ENEMY: " + other.gameObject.name + " tag: " + other.gameObject.tag);

		if (other.gameObject.tag == "Weapon")
		{
			Debug.Log(gameObject.name + ": " + "OUCH! I got hit by " + other.gameObject.name);
			if (!isDead)
			{
				TakeDamage();
			}
			else //just for testing
			{
				myRend.material.SetColor("_Color", orgColor);
				isDead = false;
			}
		}
	}

	void TakeDamage()
	{
		
		myRend.material.SetColor("_Color", hitColor);
		isDead = true;
		GameManager.Instance.setScore(value);
	}
}