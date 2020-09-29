using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanLogic : MonoBehaviour
{
    private bool fear = true;
    Rigidbody rb;
    Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (fear)
        {
            animator.Play("Sit");
            animator.speed = 0.25f;
        }
    }
}
