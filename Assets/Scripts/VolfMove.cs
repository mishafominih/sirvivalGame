
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolfMove : MonoBehaviour
{
	public GameObject target;
	public float speed = 0.02f;
	WolfMoveLogic logic;
    new WolfAnimation animation;
	
	
	void Start()
    {
		logic = GetComponent<WolfMoveLogic>();
		animation = GetComponent<WolfAnimation>();
	}

    void Update()
    {
		logic.Move(target.transform.position);
		animation.GetAnimation(logic.end);
    }

    public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			logic.end = false;
		}
	}
}
