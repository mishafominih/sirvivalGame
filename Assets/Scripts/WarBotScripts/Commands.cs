using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Commands : MonoBehaviour
{
    public List<GameObject> Models;
    public float SpeedWalk;

    private Animator animator;
    private GameObject stateNow;
    private Rigidbody rb;
    private CapsuleCollider collider;
    private float interval = 1f;
    private Timer walkTimer;

    public void Sit()
    {
        if (stateNow.name != "Sit")
        {
            StartAnim("Sit");
        }
    }

    public void Idle()
    {
        if (stateNow.name != "CalmStay")
        {
            StartAnim("CalmStay");
        }
    }

    public void Fire(GameObject target = null)
    {
        if (stateNow.name != "Shoot")
        {
            StartAnim("Shoot");
        }

        if(target == null)
        {

        }
        var v = new Vector3(
            target.transform.position.x - transform.position.x, 0, 
            target.transform.position.z - transform.position.z);
        v.Normalize();
        transform.rotation = Quaternion.LookRotation(v);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 45 , 0);
    }

    public bool Walk(Vector2 target)
    {
        var pos = new Vector2(transform.position.x, transform.position.z);
        if (Vector2.Distance(pos, target) > 0.5)
        {
            if (stateNow.name != "Walk")
            {
                StartAnim("Walk");
            }
            var v = new Vector3(target.x - transform.position.x, 0, target.y - transform.position.z);
            v.Normalize();
            v = new Vector3(v.x * SpeedWalk, 0, v.z * SpeedWalk);
            rb.MovePosition(transform.position + v);
            transform.rotation = Quaternion.LookRotation(v);
            return false;
        }
        return true;
    }

    public void Dead()
    {
        if (stateNow.name != "DeadStay")
        {
            StartAnim("DeadStay");
        }
        Destroy(gameObject, 2);
    }

    void Start()
    {
        walkTimer = new Timer(interval);
        stateNow = transform.GetChild(0).gameObject;
        animator = stateNow.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.Play("1");
    }

    private void StartAnim(string name)
    {
        Destroy(stateNow);
        stateNow = Instantiate(GetModel(name), transform);
        stateNow.name = name;
        animator = stateNow.GetComponent<Animator>();
    }

    private GameObject GetModel(string name) => Models.Where(x => x.name == name).FirstOrDefault();
}
