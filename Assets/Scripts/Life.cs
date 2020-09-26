using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public float hp = 100;
    private float life;
    public bool Alive = true;
    public float TimeDestroy = 10;
    public Scrollbar scr;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag != "Player") gameObject.tag = "target";
        life = hp;
        anim = GetComponent<Animator>();
        Alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(scr != null)
        {
            scr.GetComponent<Scrollbar>().size = 1 - life / 100;
            scr.GetComponent<Scrollbar>().value = 0;
        }
        if(life <= 0)
        {
            Destroy(gameObject, TimeDestroy);
            Alive = false;
            anim.Play("death");
        }
    }

    public void ChangeHp(float delta)
    {
        life -= delta;
    }

    public void AddHp(float delta)
    {
        life += delta;
        if (life > 100) life = 100;
    }
}
