using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Wearon : MonoBehaviour
{
    public GameObject Patron;
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
    public int realCountShell;
    

    #region Spread
    public float StartSpread;
    public float Diapazon;
    public float Intensity;
    public float normalize = 3;
    #endregion

    private Animator animator;
    private Camera cam;
    private Timer ReloadTime;
    private AudioSource au;
    private ManagerWearons mW;
    private Timer t;
    private float timer = 0;
    private bool fire = true;
    private Spread spread;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cam = GetComponentInParent<Camera>();
        au = GetComponent<AudioSource>();
        mW = GetComponentInParent<ManagerWearons>();
        realCountShell = mW.GetPatrons(patronType, CountShell);
        t = new Timer(1 / (float)RateOfFire);
        spread = new Spread(StartSpread, Diapazon, Intensity, 
            new List<string> { "left", "right", "up", "down"}
            .Select(x => mW.gameObject.GetComponentInChildren<Inventory>().canvas.transform.Find(x).gameObject)
            .ToArray(), normalize);
        ReloadTime = new Timer(AudioReload.length);
    }

    // Update is called once per frame
    void Update()
    {
        spread.Update();
        fire = t.Check();
        animator.speed = 1;
        if (Input.GetKey(KeyCode.R) && realCountShell < CountShell)
        {
            ReloadTime.Null();
            var count = mW.GetPatrons(patronType, CountShell - realCountShell);
            if (count > 0)
            {
                animator.Play("reload");
                realCountShell += count;
                au.clip = AudioReload;
                au.Play();
            }
        }
        if (ReloadTime.Check() && Input.GetMouseButton(0) && !Input.GetKey(KeyCode.I))
            if (fire && realCountShell > 0)
                Fire();
    }

    private void Fire()
    {
        animator.speed = 1;
        animator.Play("fire");
        realCountShell -= 1;
        fire = false;
        t.Null();
        Instantiate(EventOnFire, transform).transform.localPosition += PlaceEvent;
        au.clip = AudioFire;
        au.Play();

        var ray = cam.ScreenPointToRay(new Vector3(
            Screen.width * 0.5f + spread.GetDiapazon(),
            Screen.height * 0.5f + spread.GetDiapazon(), 
            0));
        var info = new RaycastHit();

        var p = Instantiate(Patron, cam.transform);
        //p.transform.localPosition += PlaceEvent;
        p.transform.SetParent(null);
        p.transform.position += ray.direction.normalized * 2;
        p.transform.rotation = transform.rotation;
        p.GetComponent<PatronSkript>().Damage = Damage;
        p.GetComponent<Rigidbody>().AddForce(ray.direction.normalized * 500);
    }
}