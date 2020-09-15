using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Info> items;
    public GameObject image;
    public Canvas canvas;
    public Transform PlayerTransform;
    private List<GameObject> cash;
    void Start()
    {
        Cursor.visible = false;
        cash = new List<GameObject>();
    }

    private Vector3 GetDirection(float angle)
    {
        var z = -Mathf.Sin(angle / 180 * Mathf.PI);
        var x = Mathf.Cos(angle / 180 * Mathf.PI);
        return new Vector3(x, 0, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && items.Count > 0)
        {
            Cursor.visible = true;
            foreach (var item in items)
            {
                var picture = Instantiate(image, canvas.transform);
                picture.GetComponent<Image>().sprite = item.image;
                cash.Add(picture);
            }
            for(int i = 0; i < Math.Min(4, cash.Count / 6 + 1); i++)
                for(int j = 0; j < Math.Min(6, cash.Count - i * 6); j++)
                {
                    cash[i * 6 + j].transform.position = new Vector3(50 + j * 100, 350 - i * 100, 0);
                }
        }
        if (Input.GetKey(KeyCode.I))
            if (Input.GetMouseButton(0))
                for (int i = 0; i < cash.Count; i++)
                {
                    var pos = Input.mousePosition;
                    var target = cash[i].transform.position;
                    if (Math.Abs(pos.x - target.x) <= cash[i].GetComponent<RectTransform>().sizeDelta.x / 2 &&
                        Math.Abs(pos.y - target.y) <= cash[i].GetComponent<RectTransform>().sizeDelta.y / 2)
                    {
                        InitializeObject(i);
                    }
                }
        if (Input.GetKeyUp(KeyCode.I))
        {
            Cursor.visible = false;
            foreach (var c in cash) Destroy(c);
            cash.Clear();
        }
    }

    private void InitializeObject(int i)
    {
        var a = Instantiate(items[i].prefab,
            PlayerTransform.position + GetDirection(PlayerTransform.rotation.eulerAngles.y - 90), 
            new Quaternion());
        a.GetComponent<Info>().prefab = items[i].prefab;
        a.GetComponent<Info>().image = items[i].image;
        items.Remove(items[i]);
        Destroy(cash[i]);
        cash.RemoveAt(i);
    }
}
