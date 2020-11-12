using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManBotLogic : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public float speed = 0.02f;
    private ManCommands commands;
    bool f = true;
    void Start()
    {
        commands = GetComponent<ManCommands>();
    }

    // Update is called once per frame
    void Update()
    {
        if (f)
        {
            if (commands.Walk(pos1, speed))
            {
                f = false;
            }
        }
        else
        {
            if (commands.Walk(pos2, speed))
            {
                f = true;
            }
        }
    }
}