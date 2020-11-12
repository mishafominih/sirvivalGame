using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 1;
    Rigidbody rb;
    Camera cam;
    private Timer timer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        timer = new Timer(0.9f);
    }

    private Vector3 GetDirection(float angle)
    {
        var z = -Mathf.Sin(angle / 180 * Mathf.PI);
        var x = Mathf.Cos(angle / 180 * Mathf.PI);
        return new Vector3(x, 0, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Check() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 20000, 0));
            timer.Null();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GetComponent<CapsuleCollider>().height /= 2;
            speed /= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GetComponent<CapsuleCollider>().height *= 2;
            speed *= 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) speed *= 1.7f;
        if (Input.GetKeyUp(KeyCode.LeftShift)) speed /= 1.7f;
        var position = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            position += GetDirection(transform.rotation.eulerAngles.y - 90) / 10;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position += GetDirection(transform.rotation.eulerAngles.y) / 10;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position += GetDirection(transform.rotation.eulerAngles.y + 90) / 10;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position += GetDirection(transform.rotation.eulerAngles.y + 180) / 10;
        }
        rb.MovePosition(position * speed + transform.position);
    }
}
