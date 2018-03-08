using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 1f;
	
    public Transform sightStart;
    public Transform sightEnd;
    public bool colliding;
    private Rigidbody2D rb2d;
    //public LayerMask detect;
	public LayerMask Ground;

	public AudioClip MusicClip;

	public AudioSource MusicSource;

    void Start ()
	{
        rb2d = GetComponent<Rigidbody2D>();
		//transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
    }
	

	void Update () 
	{
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

		colliding = Physics2D.Linecast(sightStart.position, sightEnd.position, Ground);

	
        if (colliding)
        {
			//speed *= -1;
			transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
		MusicSource.clip = MusicClip;

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().Damage(10);

			col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0,30),ForceMode2D.Impulse);
		    
			MusicSource.Play();
            
        }
    }
}
