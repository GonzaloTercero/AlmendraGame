using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    
        [SerializeField] private float m_JumpForce = 400f;                  
        [SerializeField] private bool m_AirControl = false;                 
        [SerializeField] private LayerMask m_WhatIsGround;                 

        private Transform m_GroundCheck;    
        const float k_GroundedRadius = .2f;
        private bool m_Grounded;            
        private Animator m_Anim;            
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;
        private StoneManager sm;
        private int stoneCount;


        private void Awake()
        {
     
            m_GroundCheck = transform.Find("GroundCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
			sm = GameObject.FindGameObjectWithTag("StoneManager").GetComponent<StoneManager>();
            stoneCount = 0;
        }


        private void FixedUpdate()
        {
            m_Grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

           
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }


        public void Move(float move, bool jump)
        {


            if (m_Grounded || m_AirControl)
            {
                m_Anim.SetFloat("Speed", Mathf.Abs(move));


                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);


                if (move > 0 && !m_FacingRight)
                {

                    Flip();
                }

                else if (move < 0 && m_FacingRight)
                {

                    Flip();
                }
            }


            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }
     


        private void Flip()
        {
            
            m_FacingRight = !m_FacingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            

            if (col.CompareTag("Stone"))
            {
                Destroy(col.gameObject);
                stoneCount++;
                sm.stones += 1;
            }
        }

    }
}
