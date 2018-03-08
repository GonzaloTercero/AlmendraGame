using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask ToHit;
    private int stoneCount = 2;
    public float stoneSpeed = 100;
    public GameObject stone;
    public GameObject player;
    private StoneManager sm;

	public AudioClip MusicClip;

	public AudioSource MusicSource;

    float timeToFire = 0;

    void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("StoneManager").GetComponent<StoneManager>();
    }

    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Shoot();
            }
        }
        else
        {
			if (Input.GetButton("Fire2") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    /*void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100, ToHit);
        Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100);
      
    }*/

    public void Shoot()
    {
		MusicSource.clip = MusicClip;

		if (sm.stones > 0)
        {
            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            GameObject stoneClone;
            stoneClone = Instantiate(stone) as GameObject;

            if (mousePosition.x >= player.transform.position.x)
            {
                stoneClone.transform.position = player.transform.position + player.transform.right;
                stoneClone.GetComponent<Rigidbody2D>().velocity = mousePosition * stoneSpeed;
                stoneCount--;
                sm.stones -= 1;
				MusicSource.Play();
            }

            else if (mousePosition.x < player.transform.position.x)
            {
                stoneClone.transform.position = player.transform.position - player.transform.right;
                stoneClone.GetComponent<Rigidbody2D>().velocity = -mousePosition * stoneSpeed;
                stoneCount--;
                sm.stones -= 1;
				MusicSource.Play();
            }

			Destroy (stoneClone, 2);
        }

    }

    
}