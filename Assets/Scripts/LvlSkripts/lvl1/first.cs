using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first : MonoBehaviour
{
    public List<GameObject> zombi;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            zombi.ForEach(z =>
            {
                z.GetComponent<VolfMove>().target = other.gameObject;
            });
        }
    }
}
