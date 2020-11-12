using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseLight : MonoBehaviour
{
    public bool use = false;
    private bool enable = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Light>().enabled = enable;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && use)
        {
            enable = enable ? false : true;
            GetComponent<Light>().enabled = enable;
        }
    }
}
