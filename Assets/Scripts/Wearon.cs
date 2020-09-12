using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wearon : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
            animator.Play("reload");
        if (Input.GetMouseButton(0))
            animator.Play("fire");
    }
}
