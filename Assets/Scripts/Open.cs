using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Open : MonoBehaviour
{
    public int next;
    public Vector3 NextPosition;
    public GameObject g;
    // Update is called once per frame

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.F) && g.GetComponentInChildren<LightGanerator>().on)
            {
                SceneManager.LoadScene(next);
                GameObject.FindGameObjectWithTag("Player").transform.position = NextPosition;
            }
        }
    }
}
