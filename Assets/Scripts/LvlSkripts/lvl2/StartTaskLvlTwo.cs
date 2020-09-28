using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTaskLvlTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Tasks>().SetTask("Обыскать объект в поисках выживших");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
