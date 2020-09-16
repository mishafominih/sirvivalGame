using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMoveLogic : MonoBehaviour
{
	public bool end = false;


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
		float deltaX = target.x - transform.position.x;
		float deltaZ = target.z - transform.position.z;
		if (Mathf.Abs(deltaX) >= 0.5 || Mathf.Abs(deltaZ) >= 0.5)
		{
			if (end != true)
			{
				float angle = Mathf.Atan2(deltaZ, deltaX);
				//if (Rotate)
					rb.rotation = Quaternion.Euler(rb.rotation.x, 90 - angle * 180 / Mathf.PI, 0);
				transform.position += new Vector3(volf.speed * Mathf.Cos(angle), 0,
					volf.speed * Mathf.Sin(angle));
				//Rotate = false;
			}
		}
		//else Rotate = true;
	}
}
