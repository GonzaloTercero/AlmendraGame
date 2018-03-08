using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour {

	public int curHealth;
	public int maxHealth = 100;

	void Start()
	{
		curHealth = maxHealth;

	}

	void Update()
	{
		if(curHealth > maxHealth)
		{
			curHealth = maxHealth;
		}

		if(curHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);

	}

	public void Damage(int dmg)
	{
		curHealth -= dmg;
	}
}
