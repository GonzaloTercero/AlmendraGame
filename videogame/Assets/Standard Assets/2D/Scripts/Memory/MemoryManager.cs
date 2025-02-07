﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MemoryManager : MonoBehaviour {

	public const int gridRows = 2;
	public const int gridCols = 2;
	public const float offsetX = 3.2f;
	public const float offsetY = 4.1f;
	private int countMatch = 0;
	//public GameObject[] Cards;


	[SerializeField] private MainCard originalCard;
	[SerializeField] private Sprite[] images;

	private void Start()
	{
		Vector3 startPos = originalCard.transform.position;

		int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
		numbers = ShuffleArray (numbers);

		for (int i = 0; i < gridCols; i++) 
		{
			for (int j = 0; j < gridRows; j++) 
			{
				MainCard card;
				if (i == 0 && j == 0) {
					card = originalCard;
				} 
				else
				{
					card = Instantiate(originalCard) as MainCard;
				}
					
				int index = j * gridCols + 1;
				int id = numbers [index]; 
				card.ChangeSprite(id, images[id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = (offsetY * j) + startPos.y;
				card.transform.position = new Vector3 (posX, posY, startPos.z);
			}
		}
	}

	private int[] ShuffleArray(int[] numbers)
	{
		int[] newArray = numbers.Clone() as int[];
		for(int i = 0; i < newArray.Length; i++)
		{
			int tmp = newArray [i];
			int r = Random.Range (i, newArray.Length);
			newArray[i] = newArray[r];
			newArray [r] = tmp;
			
		}
		return newArray;
	}


	private MainCard _firstRevealed;
	private MainCard _secondRevealed;

	public bool canReveal
	{
		get { return _secondRevealed == null;}
	}

	public void CardRevealed(MainCard card)
	{
		if (_firstRevealed == null) {
			_firstRevealed = card;
		} 
		else 
		{
			_secondRevealed = card;
			StartCoroutine (CheckMatch ());
		}
	}

	private IEnumerator CheckMatch ()
	{
		yield return new WaitForSeconds (0.5f);

		if (_firstRevealed.id == _secondRevealed.id) {
			countMatch++;
			CheckFinished ();

		} 
		else 
		{
			yield return new WaitForSeconds (0.5f);

			_firstRevealed.Unreveal();
			_secondRevealed.Unreveal();
		}

		_firstRevealed = null;
		_secondRevealed = null;
	}

	void CheckFinished(){
		countMatch++;

		if (countMatch == 4) {
			
			GameObject[] Cards = GameObject.FindGameObjectsWithTag ("Card");

			foreach (GameObject Card in Cards) { 
				Destroy (Card);
			}
	}
}
}
