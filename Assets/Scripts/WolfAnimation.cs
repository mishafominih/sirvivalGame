using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateAnimation
{
	Run,
	Stay,
	sniff,
	sit
}
public class WolfAnimation : MonoBehaviour
{
	Animator anim;
	void Start()
    {
		anim = GetComponent<Animator>();
	}
	
    public void GetAnimation(bool end)
    {
		if (end) anim.Play("default");
		else anim.Play("run");
	}
}
