using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinaTalk : MonoBehaviour
{
    AudioClip Talk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().clip = Talk;
            GetComponent<AudioSource>().Play();
            other.gameObject.GetComponent<Tasks>().SetTask("");

            GetComponent<BoxCollider>().enabled = false;
            enabled = false;
        }
    }
}
