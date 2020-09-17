using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamApproach : MonoBehaviour
{
    public float AppRoach = 15;
    Camera cam;
    float fieldView;
    void Start()
    {
        cam = GetComponent<Camera>();
        fieldView = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetKey(KeyCode.I) && Input.GetMouseButtonDown(1))
        {
            cam.fieldOfView = fieldView - AppRoach;
        }
        if (!Input.GetKey(KeyCode.I) && Input.GetMouseButtonUp(1))
        {
            cam.fieldOfView = fieldView;
        }

    }
}
