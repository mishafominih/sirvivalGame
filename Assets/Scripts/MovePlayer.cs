﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 1;
    Rigidbody rb;
    Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 22000, 0));
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
        if (Input.GetKeyDown(KeyCode.LeftShift)) speed *= 2;
        if (Input.GetKeyUp(KeyCode.LeftShift)) speed /= 2;
        if (Input.GetKey(KeyCode.W))
        {
            var position = GetDirection(transform.rotation.eulerAngles.y - 90) / 10 * speed;
            rb.MovePosition(position + transform.position);
        }
        if (Input.GetKey(KeyCode.D))
        {
            var position = GetDirection(transform.rotation.eulerAngles.y) / 10 * speed;
            rb.MovePosition(position + transform.position);
        }
        if (Input.GetKey(KeyCode.S))
        {
            var position = GetDirection(transform.rotation.eulerAngles.y + 90) / 10 * speed;
            rb.MovePosition(position + transform.position);
        }
        if (Input.GetKey(KeyCode.A))
        {
            var position = GetDirection(transform.rotation.eulerAngles.y + 180) / 10 * speed;
            rb.MovePosition(position + transform.position);
        }
    }
}
