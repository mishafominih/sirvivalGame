using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManLogic : MonoBehaviour
{
    private ManCommands commands;
    void Start()
    {
        commands = GetComponent<ManCommands>();
    }

    // Update is called once per frame
    void Update()
    {
         commands.Idle();
    }
}
