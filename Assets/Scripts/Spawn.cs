using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> Enemyes;
    public List<Vector3> Plases;
    public int count;
    public int RealCount = 5;
    public List<GameObject> Doors;
    private List<GameObject> real;
    private bool start = false;
    private GameObject player;
    private int counter = 0;

    private void Start()
    {
        real = new List<GameObject>();
    }

    private Vector3 getRandVector()
    {
        return Plases[Random.Range(0, Plases.Count)] + new Vector3(
            Random.Range(0f, 1f), 0, Random.Range(0f, 1f));
    }

    private void Update()
    {
        real = real.Where(x => x != null).ToList();
        if (start && counter < count)
        {
            for (int i = 0; i < RealCount - real.Count; i++)
            {
                var g = Instantiate(Enemyes[Random.Range(0, Enemyes.Count)],
                    getRandVector(), new Quaternion());
                g.GetComponent<VolfMove>().target = player;
                real.Add(g);
                counter++;
            }
        }
        if(counter >= count && real.Count == 0)
        {
            Doors.ForEach(x =>
            {
                x.GetComponent<OpenDoor>().Open();
                x.GetComponent<OpenDoor>().can = true;
            });
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            start = true;
            Doors.ForEach(x =>
            {
                x.GetComponent<OpenDoor>().Close();
                x.GetComponent<OpenDoor>().can = false;
            });
            player = other.gameObject;
        }
    }
}
