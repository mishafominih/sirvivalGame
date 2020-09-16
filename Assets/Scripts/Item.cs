using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item
{
    Sprite Image { get; set; }

    GameObject Prefab { get; set; }

    Item UseItem(GameObject player);

    void SetTag();
}
