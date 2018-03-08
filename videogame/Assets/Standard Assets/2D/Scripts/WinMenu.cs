using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

	public GameObject WinUI;

	public void MainMenu()
	{
		SceneManager.LoadScene(1);
	}

}