using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Commands : MonoBehaviour
{
    public List<GameObject> Models;

    private GameObject stateNow;

    public void Idle()
    {
        StartAnim("CalmStay");
    }

    public void Fire()
    {
        StartAnim("Shoot");
    }

    public void Dead()
    {
        StartAnim("DeadStay");
        Destroy(gameObject, 2);
    }

    void Start()
    {
        stateNow = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        stateNow.GetComponent<Animator>().Play("1");
    }

    private void StartAnim(string name)
    {
        if (stateNow.name != name)
        {
            Destroy(stateNow);
            stateNow = Instantiate(GetModel(name), transform);
            stateNow.name = name;
        }
    }

    private GameObject GetModel(string name)
    {
        return Models.Where(x => x.name == name).FirstOrDefault();
    }
}
