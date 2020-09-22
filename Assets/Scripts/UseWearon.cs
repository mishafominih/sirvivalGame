using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWearon : MonoBehaviour, Item
{
    [SerializeField] private Sprite image;
    [SerializeField] private GameObject prefab;
    public GameObject Wearon;
    public GameObject Prefab { get => prefab; set => prefab = value; }
    public Sprite Image { get => image; set => image = value; }

    public void SetTag()
    {
        tag = "Item";
    }

    public Item UseItem(GameObject player)
    {
        GameObject go = player.GetComponent<ManagerWearons>().ReplaceWearon(Wearon);
        return go == null ? null : go.GetComponent<Item>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTag();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
