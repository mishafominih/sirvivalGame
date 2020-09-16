using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerWearons : MonoBehaviour
{
    public List<GameObject> Wearons;
    private GameObject wearonNow;
    private int index = 0;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        if(Wearons.Count > 0)
        {
            wearonNow = Instantiate(Wearons[0], cam.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.magnitude > 0 && Wearons.Count > 1)
        {
            Destroy(wearonNow);
            if (index == Wearons.Count - 1)
            {
                wearonNow = Instantiate(Wearons[0], cam.transform);
                index = 0;
            }
            else
            {
                wearonNow = Instantiate(Wearons[++index], cam.transform);
            }
        }
    }

    public GameObject ReplaceWearon(GameObject newWearon)
    {
        var res = wearonNow.GetComponent<Wearon>().Item;
        Destroy(wearonNow);
        Wearons[index] = newWearon;
        wearonNow = Instantiate(Wearons[index], cam.transform);
        return res;
    }
}
