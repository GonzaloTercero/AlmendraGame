using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D col)
    {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerHealth>().Damage(10);
				Destroy(gameObject);
			}
    }
}
