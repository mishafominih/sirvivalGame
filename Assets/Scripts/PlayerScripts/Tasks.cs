using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    public GameObject text;

    private Canvas canvas;
    private string task;
    private GameObject GameObject;
    
    public void SetTask(string newTask)
    {
        task = newTask;
    }

    private void Start()
    {
        canvas = GetComponentInChildren<Inventory>().canvas;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject = Instantiate(text, canvas.transform);
            GameObject.GetComponent<Text>().text = task;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Destroy(GameObject);
        }
    }
}
