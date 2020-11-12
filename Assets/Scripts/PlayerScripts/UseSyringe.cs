using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSyringe : MonoBehaviour, Item
{
    public float AddHp = 50;
    [SerializeField] private Sprite image;
    [SerializeField] private GameObject prefab;
    public Sprite Image { get => image; set => image = value; }
    public GameObject Prefab { get => prefab; set => prefab = value; }

    public void SetTag()
    {
        tag = "Item";
    }

    public Item UseItem(GameObject player)
    {
        player.GetComponent<Life>().AddHp(AddHp);
        return null;
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
