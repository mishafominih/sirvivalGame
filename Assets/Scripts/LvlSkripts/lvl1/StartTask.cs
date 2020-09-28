using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Tasks>().SetTask("запустить генератор");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
