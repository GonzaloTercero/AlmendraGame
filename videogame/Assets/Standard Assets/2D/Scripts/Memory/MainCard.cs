using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour {

	[SerializeField] private MemoryManager memoryManager;
	[SerializeField] private GameObject Card_back;
	[SerializeField] private GameObject Maincard;

	public void OnMouseDown()
	{
		if (Card_back.activeSelf && memoryManager.canReveal) 
		{
			Card_back.SetActive (false);
			memoryManager.CardRevealed (this);
		}
	}

	private int _id;

	public int id
	{
		get { return _id;}
	}

	public void ChangeSprite( int id, Sprite image)
	{
		_id = id;
		GetComponent<SpriteRenderer> ().sprite = image;
	}

	public void Unreveal()
	{
		Card_back.SetActive (true);
	}

	public void Match()
	{
		Card_back.SetActive (false);
		Maincard.SetActive (false);

	}
		
}
