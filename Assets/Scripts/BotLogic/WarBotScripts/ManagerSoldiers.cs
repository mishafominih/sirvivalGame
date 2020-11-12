using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSoldiers : MonoBehaviour
{
    public GameObject soldier;
    public List<GameObject> Plases;
    public List<Vector3> SoldiersSpawn;
    public int count;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var l = new List<GameObject>();
            for (int i = 0; i < count; i++)
            {
                var s = Instantiate(
                    soldier, SoldiersSpawn[Random.Range(0, SoldiersSpawn.Count)], new Quaternion());
                l.Add(s);
                s.GetComponent<WarLogic>().SetStartSetting(l, Plases, Random.Range(0, 1), other.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
