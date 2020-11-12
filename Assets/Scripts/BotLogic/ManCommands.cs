using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManCommands : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public bool Run(Vector3 pos, float speed)
    {
        return move(pos, speed, "Run");
    }

    private bool move(Vector3 pos, float speed, string name)
    {
        if (Vector2.Distance(new Vector2(pos.x, pos.z),
            new Vector2(transform.position.x, transform.position.z)) <= speed * 5) {
            transform.position = new Vector3(pos.x, transform.position.y, pos.z);
            return true;
        }
        animator.Play(name);
        var target = pos - transform.position;
        target = new Vector3(target.x, 0, target.z);
        target.Normalize();
        transform.rotation = Quaternion.LookRotation(new Vector3(target.x, 0, target.z));
        target = new Vector3(transform.position.x + target.x * speed,
            transform.position.y,
            transform.position.z + target.z * speed);
        rb.MovePosition(target);
        return false;
    }

    public bool Walk(Vector3 pos, float speed)
    {
        return move(pos, speed, "Walk");
    }

    public void Sit()
    {
        animator.Play("Sit");
    }

    public void Idle()
    {
        animator.Play("Idle");
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
}
