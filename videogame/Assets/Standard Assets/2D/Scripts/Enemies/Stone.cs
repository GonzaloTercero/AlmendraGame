using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			col.gameObject.GetComponent<EnemyHealth>().Damage(10);
			Destroy(gameObject);
		}
	}


}

