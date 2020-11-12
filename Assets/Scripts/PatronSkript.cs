using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronSkript : MonoBehaviour
{
    public float Damage;

    private void Start()
    {
        Destroy(gameObject, 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        var g = other.gameObject;
        while (g.transform.parent != null)
        {
            g = g.transform.parent.gameObject;
        }

        if (g.gameObject.tag == "target")
        {
            g.gameObject.GetComponent<Life>().ChangeHp(Damage);
        }
        if (g.transform.gameObject.tag == "soldier")
        {
            g.transform.GetComponent<WarLogic>().ChangeHp(Damage);
        }
        Destroy(gameObject);
    }
}
