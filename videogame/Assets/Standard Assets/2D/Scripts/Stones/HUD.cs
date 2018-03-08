using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour {

    public Sprite[] HealthBarSprites;

    public Image HealthUI;

    private PlayerHealth player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
		HealthUI.sprite = HealthBarSprites[player.getHUD()];
    }
}
