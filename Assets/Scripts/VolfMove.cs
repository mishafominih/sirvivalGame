
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolfMove : MonoBehaviour
{
	public GameObject target;
	public float speed = 0.02f;
	public float Distance = 15;
	WolfMoveLogic logic;
	Life life;
    new WolfAnimation animation;
	
	private bool GetDistanceToTarget()
    {
		return Vector3.Distance(transform.position, target.transform.position) <= Distance ? true : false;
    }
	
	void Start()
    {
		logic = GetComponent<WolfMoveLogic>();
		animation = GetComponent<WolfAnimation>();
		life = GetComponent<Life>();
	}

    void Update()
	{
		if (target != null)
		{
			if (!GetDistanceToTarget()) logic.end = false;
			if (life.Alive && GetDistanceToTarget())
			{
				logic.Move(target.transform.position);
				animation.GetAnimation(logic.end, logic.Attack);
			}
		}
    }
}
