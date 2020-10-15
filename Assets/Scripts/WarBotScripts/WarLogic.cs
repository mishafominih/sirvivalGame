using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WarLogic : MonoBehaviour
{
    public float hp = 150;

    private List<GameObject> freePlaces;//список свободных укрытий
    private Commands commands;
    private Timer start;
    private GameObject place;//место, в котором прячется солдат
    private bool onPlace = false;//ложь, если солдат не добрался до места
    private GameObject player;
    private bool hit = false;//попадание
    private Timer hide;//время, с первого попадания и до того как спрячется
    private Timer wait;//время появления из укрытия
    public void SetStartSetting(List<GameObject> s, List<GameObject> p, float start, GameObject pl = null)
    {
        freePlaces = p;
        this.start = new Timer(start);
        player = pl;
    } 

    public void ChangeHp(float damage)
    {
        hp -= damage;
        hit = true;
    }

    void Start()
    {
        commands = GetComponent<Commands>();
        hide = new Timer(1.5f);
        wait = new Timer(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (start.Check())
        {
            if(hp <= 0)
            {
                commands.Dead();
                return;
            }
            if(place == null && freePlaces.Count > 0)
            {
                place = freePlaces
                    .OrderBy(x => Vector3.Distance(transform.position, x.transform.position))
                    .First();
                freePlaces.RemoveAt(0);
            }
            if(place != null)
            {
                var p = place.GetComponent<Place>();
                if (onPlace || commands.Walk(p.GetPosition("def")))
                {
                    onPlace = true;
                    logic(p);
                }
            }
        }
    }

    private void logic(Place p)
    {
        if (!hit || !hide.Check())
        {
            if (commands.Walk(new Vector2(p.GetPosition("attack").x, p.GetPosition("attack").y)))
            {
                transform.position = new Vector3(
                    p.GetPosition("attack").x,
                    transform.position.y,
                    p.GetPosition("attack").y);
                commands.Fire(player);
            }
            return;
        }
        if (commands.Walk(new Vector2(p.GetPosition("def").x, p.GetPosition("def").y)))
        {
            transform.position = new Vector3(
                p.GetPosition("def").x,
                transform.position.y,
                p.GetPosition("def").y);
            if (p.isSit)
            {
                commands.Sit();
            }
            else
            {
                commands.Idle();
            }
            if (wait.Check())
            {
                hit = false;
                hide.Null();
                wait.Null();
            }
        }
    }
}
