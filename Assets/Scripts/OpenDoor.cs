using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool open = false;
    public bool can = true;
    // Start is called before the first frame update
    void Start()
    {
        tag = "Door";
    }

    // Update is called once per frame
    public void OpenOrClose()
    {
        if (can)
        {
            if (open)
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 90, 0);
                open = false;

            }
            else
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 90, 0);
                open = true;
            }
        }
    }
}
