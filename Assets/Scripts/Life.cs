using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float hp = 100;
    private float life;
    public bool Alive;
    public float TimeDestroy = 10;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "target";
        life = hp;
        anim = GetComponent<Animator>();
        Alive = true;
    }

    // Update is called once per frame
    void Update()
    {
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
}
