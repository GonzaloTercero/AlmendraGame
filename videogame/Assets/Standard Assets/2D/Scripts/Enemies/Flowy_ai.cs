﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowy_ai : MonoBehaviour {

    public int curHealth;
    public int maxHealth;

    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    public bool awake = false;
    public bool lookingRight = true;

    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;
	public AudioClip MusicClip;

	public AudioSource MusicSource;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
		MusicSource.clip = MusicClip;

    }

    void Start()
    {
        curHealth = maxHealth;

    }

    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);

        RangeCheck();

        if(target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }

        if(target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }

    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if(distance < wakeRange)
        {
            awake = true;
        }

        if(distance > wakeRange)
        {
            awake = false;
        }

    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if(bulletTimer >= shootInterval)
        {
			

            if (attackingRight)
            {
                GameObject bulletClone;
				bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(1,0) * bulletSpeed;
				MusicSource.Play();
                bulletTimer = 0;
            }
        
            if(!attackingRight)
            {
                GameObject bulletClone;
				bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-1,0) * bulletSpeed;
				MusicSource.Play();
                bulletTimer = 0;
            }
        }
    }
}
