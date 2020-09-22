using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wearon : MonoBehaviour
{
    Animator animator;
    Camera cam;
    public GameObject Item;
    public int RateOfFire = 4; // кол-во выстрелов в секунду
    public int CountShell = 30;//патрон в магазине
    public int Distance = 1000;
    public Patron patronType;
    public float Damage;
    public ParticleSystem EventOnFire;
    public Vector3 PlaceEvent;
    public AudioClip AudioFire;
    public AudioClip AudioReload;
    private AudioSource au;
    private ManagerWearons mW;
    

    public int realCountShell;
    private float timer = 0;
    private bool fire = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cam = GetComponentInParent<Camera>();
        au = GetComponent<AudioSource>();
        mW = GetComponentInParent<ManagerWearons>();
        realCountShell = mW.GetPatrons(patronType, CountShell);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fire)
        {
            timer += Time.deltaTime;
            if(timer >= 1 / (float)RateOfFire)
            {
                fire = true;
                timer = 0;
            }
        }
        animator.speed = 1;
        if (Input.GetKey(KeyCode.R) && realCountShell < CountShell)
        {
            mW.AddPatrons(patronType, realCountShell);
            var count = mW.GetPatrons(patronType, CountShell);
            if (count > 0)
            {
                animator.Play("reload");
                realCountShell = count;
                au.clip = AudioReload;
                au.Play();
            }
        }
        if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.I))
            if (fire && realCountShell > 0)
                Fire();
    }
    
    private void Fire()
    {
        animator.speed = 1;
        animator.Play("fire");
        realCountShell -= 1;
        fire = false;
        Instantiate(EventOnFire, transform).transform.localPosition += PlaceEvent;
        au.clip = AudioFire;
        au.Play();

        var ray = cam.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
        var info = new RaycastHit();
        if (Physics.Raycast(ray, out info, Distance))
        {
            if(info.collider.gameObject.tag == "target")
            {
                info.collider.gameObject.GetComponent<Life>().ChangeHp(Damage);
            }
        }
    }
}
