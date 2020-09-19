
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolfMove : MonoBehaviour
{
	public GameObject target;
	public float speed = 0.02f;
	WolfMoveLogic logic;
	Life life;
    new WolfAnimation animation;
	
	
	void Start()
    {
		logic = GetComponent<WolfMoveLogic>();
		animation = GetComponent<WolfAnimation>();
		life = GetComponent<Life>();
	}

    void Update()
	{
		if (life.Alive && target != null)
		{
			logic.Move(target.transform.position);
			animation.GetAnimation(logic.end);
		}
    }

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.collider.tag == "Player")
		{
			logic.end = false;
		}
	}
}
