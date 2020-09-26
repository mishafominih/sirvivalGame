
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolfMove : MonoBehaviour
{
	public GameObject target;
	public float InstatiateTime = 3;
	public float speed = 0.02f;
	public float Distance = 45;
	WolfMoveLogic logic;
	Life life;
    new WolfAnimation animation;
	Timer timer;
	
	private bool GetDistanceToTarget()
    {
		return Vector3.Distance(transform.position, target.transform.position) <= Distance ? true : false;
    }

	void Start()
	{
		logic = GetComponent<WolfMoveLogic>();
		animation = GetComponent<WolfAnimation>();
		life = GetComponent<Life>();
		timer = new Timer(InstatiateTime);
	}

    void Update()
	{
		if (timer.Check())
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
}
