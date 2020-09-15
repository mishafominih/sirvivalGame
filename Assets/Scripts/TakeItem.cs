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
            if (Physics.Raycast(ray, out info, 2))
            {
                if(info.collider.tag == "Item")
                {
                    inv.items.Add(info.collider.gameObject.GetComponent<Info>());
                    Destroy(info.collider.gameObject);
                }
            }
        }
    }
}
