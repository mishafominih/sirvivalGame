using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMoveLogic : MonoBehaviour
{
	public bool end = false;
	public bool Attack = false;


	//bool Rotate = true;
	Rigidbody rb;
	VolfMove volf;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		volf = GetComponent<VolfMove>();
	}

	public void Move(Vector3 target)
	{
		Attack = false;
		float deltaX = target.x - transform.position.x;
		float deltaZ = target.z - transform.position.z;
		if (Vector3.Distance(target, transform.position) >= 2)
		{
			if (end != true)
			{
				float angle = Mathf.Atan2(deltaZ, deltaX);
				//if (Rotate)
				rb.rotation = Quaternion.Euler(rb.rotation.x, 90 - angle * 180 / Mathf.PI, 0);
				rb.MovePosition(transform.position + new Vector3(volf.speed * Mathf.Cos(angle), 0,
					volf.speed * Mathf.Sin(angle)));
				//Rotate = false;
			}
		}
		else
		{
			//Rotate = true;
			Attack = true;
		}
	}
}
