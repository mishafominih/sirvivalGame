using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TinaTalk : MonoBehaviour
{
    AudioClip Talk;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(5);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Talk>().audios.Count == 0 && timer.Check())
        {
            
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<Talk>().StartTalk();
            other.gameObject.GetComponent<Tasks>().SetTask("");
            GetComponent<WomanLogic>().fear = false;

            GetComponent<BoxCollider>().enabled = false;
            //enabled = false;
        }
    }
}
