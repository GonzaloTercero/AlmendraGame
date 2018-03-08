using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Estrella : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(3);
		}
	}
}
