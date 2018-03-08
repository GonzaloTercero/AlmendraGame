using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	public GameObject GameOverUI;

	public void MainMenu()
	{
		SceneManager.LoadScene(1);
	}

	public void Restart()
	{
		SceneManager.LoadScene(0);
	}
}
