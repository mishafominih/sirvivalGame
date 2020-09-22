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
	bool isStart;
	public float start = 2;
	public float end = 4;
	private float duration;
	private float timer;
	Animator anim;
	void Start()
    {
		anim = GetComponent<Animator>();
		isStart = true;
		anim.Play("start");
		duration = Random.Range(start, end);
	}

    private void Update()
    {
		if (isStart)
		{
			timer += Time.deltaTime;
			if (timer >= duration) isStart = false;
		}
	}

    public void GetAnimation(bool end, bool attack)
	{
		if (attack) anim.Play("attack");
		else if (end) anim.Play("default");
		else anim.Play("run");
	}
}
