using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateLamp : MonoBehaviour
{
    public float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Speed += Random.Range(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Speed, 0);
    }
}
