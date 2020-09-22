using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerWearons : MonoBehaviour
{
    public List<GameObject> Wearons;
    public Dictionary<Patron, int> Patrons;
    public GameObject wearonNow;
    private int index = 0;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        Patrons = new Dictionary<Patron, int>();
        if(Wearons.Count > 0)
        {
            wearonNow = Instantiate(Wearons[0], cam.transform);
        }
    }

    public void AddPatrons(Patron type, int count)
    {
        if(Patrons.ContainsKey(type))
            Patrons[type] += count;
        else
            Patrons[type] = count;
    }

    public int GetPatrons(Patron type, int MaxCount)
    {
        AddPatrons(type, 0);
        if(Patrons[type] >= MaxCount)
        {
            Patrons[type] -= MaxCount;
            return MaxCount;
        }
        var count = Patrons[type];
        Patrons[type] = 0;
        return count;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.magnitude > 0 && Wearons.Count > 1)
        {
            Wearon wearon = wearonNow.GetComponent<Wearon>();
            AddPatrons(wearon.patronType, wearon.realCountShell);
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
        var res = wearonNow == null ? null : wearonNow.GetComponent<Wearon>().Item;
        Destroy(wearonNow);
        Wearons[index] = newWearon;
        wearonNow = Instantiate(Wearons[index], cam.transform);
        return res;
    }
}

public enum Patron
{
    ak74,
    cz805
}
