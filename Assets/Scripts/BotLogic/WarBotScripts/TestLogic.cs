using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogic : MonoBehaviour
{
    private Commands commands;
    private Timer test;
    void Start()
    {
        commands = GetComponent<Commands>();
        test = new Timer(3);
    }


    void Update()
    {
        if (commands.Walk(new Vector2(0f, -38)))
        {
            commands.Dead();
        }
    }
}
