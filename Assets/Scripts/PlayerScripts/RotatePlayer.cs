using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Camera cam;
    public float sensitivityX = 1;
    public float sensitivityY = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I)) return;
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");
        transform.Rotate(0, x * sensitivityX, 0);
        cam.transform.Rotate(-y * sensitivityY, 0, 0);
    }
}
