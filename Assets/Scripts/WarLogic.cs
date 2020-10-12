using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarLogic : MonoBehaviour
{
    private Commands commands;
    private Timer test;
    void Start()
    {
        commands = GetComponent<Commands>();
        test = new Timer(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (test.Check())
        {
            commands.Dead();
        }
        else
        {
            commands.Fire();
        }
    }
}
