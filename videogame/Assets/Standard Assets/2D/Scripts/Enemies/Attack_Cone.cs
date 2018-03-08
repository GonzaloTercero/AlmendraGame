using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Cone : MonoBehaviour {

    public Flowy_ai FlowyAI;

    public bool isLeft = false;

	void Awake()
    {
        FlowyAI = gameObject.GetComponentInParent<Flowy_ai>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                FlowyAI.Attack(false);
            }
            else
            {
                FlowyAI.Attack(true);
            }

        }
    }
}
