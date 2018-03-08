using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int curHealth;
    public int maxHealth = 100;

    void Awake()
    {
        curHealth = maxHealth;

    }

    void Update()
    {
		Debug.Log (curHealth);
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
        SceneManager.LoadScene(1);
        
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }

	public int getHUD(){

		int index = 0;
		if (curHealth == 100) {
			index = 5;
		} else if (curHealth < 100 && curHealth >= 75) {
			index = 4;
		} else if (curHealth < 75 && curHealth >= 50) {
			index = 3;
		} else if (curHealth < 50 && curHealth >= 25) {
			index = 2;
		} else if (curHealth < 25 && curHealth > 0) {
			index = 1;
		} else {
			index = 0;
		} 
		return index;
	}
}
