using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpforce : MonoBehaviour {

	private Rigidbody2D rb2d;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			
			col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0,30),ForceMode2D.Impulse);

		}
	}
}
