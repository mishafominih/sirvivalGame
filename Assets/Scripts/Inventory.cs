using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public GameObject image;
    public GameObject text;
    public Canvas canvas;
    public GameObject Player;
    private List<GameObject> cash;
    private ManagerWearons mW;
    void Start()
    {
        Cursor.visible = false;
        cash = new List<GameObject>();
        mW = GetComponentInParent<ManagerWearons>();
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            Drow();
        }
        if (Input.GetKey(KeyCode.I))
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
                for (int i = 0; i < cash.Count; i++)
                {
                    var pos = Input.mousePosition;
                    var target = cash[i].transform.position;
                    if (Math.Abs(pos.x - target.x) <= cash[i].GetComponent<RectTransform>().sizeDelta.x / 2 &&
                        Math.Abs(pos.y - target.y) <= cash[i].GetComponent<RectTransform>().sizeDelta.y / 2)
                    {
                        if (Input.GetMouseButtonDown(0))
                            InitializeObject(i);
                        if (Input.GetMouseButtonDown(1))
                        {
                            var item = items[i].UseItem(Player);
                            if (item != null) items[i] = item;
                            else items.RemoveAt(i);
                        }
                    }
                }
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            Cursor.visible = false;
            foreach (var c in cash) Destroy(c);
            cash.Clear();
        }
    }

    private void Drow()
    {
        Cursor.visible = true;
        if (items.Count > 0)
        {
            foreach (var item in items)
            {
                var picture = Instantiate(image, canvas.transform);
                picture.GetComponent<Image>().sprite = item.Image;
                cash.Add(picture);
            }
            for (int i = 0; i < Math.Min(4, cash.Count / 6 + 1); i++)
                for (int j = 0; j < Math.Min(6, cash.Count - i * 6); j++)
                {
                    cash[i * 6 + j].transform.position = new Vector3(50 + j * 100, 350 - i * 100, 0);
                }
        }
        int height = 1;
        foreach (var tuple in mW.Patrons)
        {
            var t = Instantiate(text, canvas.transform);
            Text text1 = t.GetComponent<Text>();
            text1.text = tuple.Key.ToString() + ": " + tuple.Value.ToString();
            t.transform.position = new Vector3(Screen.width - 100, height++ * 50);
            text1.fontSize = 35;
            text1.color = Color.white;
            cash.Add(t);
        }
    }

    private void InitializeObject(int i)
    {
        var a = Instantiate(items[i].Prefab,
            Player.transform.position + GetDirection(Player.transform.rotation.eulerAngles.y - 90), 
            new Quaternion());
        a.GetComponent<Item>().Prefab = items[i].Prefab;
        a.GetComponent<Item>().Image = items[i].Image;
        items.Remove(items[i]);
        Destroy(cash[i]);
        cash.RemoveAt(i);
    }
}
