using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGanerator : MonoBehaviour
{
    public bool on = true;

    private void Start()
    {
        SetLight();
    }

    public void SetLight()
    {
        GetComponent<Light>().enabled = on;
    }
}
