using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    Inventory inv;
    void Start()
    {
        inv = GetComponentInChildren<Inventory>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var ray = cam.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
            var info = new RaycastHit();
            if (Physics.Raycast(ray, out info, 3))
            {
                if(info.collider.tag == "Item")
                {
                    Item item = info.collider.gameObject.GetComponent<Item>();
                    inv.items.Add(item);
                    if(item is UseWearon)
                    {
                        var w = ((UseWearon)item).Wearon.GetComponent<Wearon>();
                        GetComponentInParent<ManagerWearons>().AddPatrons(w.patronType, w.CountShell);
                    }
                    Destroy(info.collider.gameObject);
                }
                if (info.collider.tag == "Door")
                {
                    var o = info.collider.gameObject.GetComponent<OpenDoor>();
                    o.OpenOrClose();
                }
                if (info.collider.tag == "Patrons")
                {
                    var p = info.collider.gameObject.GetComponent<Patrons>();
                    GetComponentInParent<ManagerWearons>().AddPatrons(p.Type, p.Count);
                    Destroy(info.collider.gameObject);
                }
                if (info.collider.tag == "Light")
                {
                    GetComponentInChildren<UseLight>().use = true;
                    Destroy(info.collider.gameObject);
                }
                if (info.collider.tag == "Generator")
                {
                    info.collider.gameObject.GetComponent<ListLight>().Lights
                        .ForEach(l =>
                        {
                            l.GetComponentInChildren<LightGanerator>().on = true;
                            l.GetComponentInChildren<LightGanerator>().SetLight();
                        });
                    gameObject.GetComponent<Tasks>().SetTask("Найти выход");
                }
            }
        }
    }
}
