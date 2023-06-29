using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float startTime;
    public float waitTime;
    private Animator anim;
    private PolygonCollider2D coll2D;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     collision.GetComponent<Attribute>()?.TakeDamage(this);

    }
    void Attack()
    {
        if(waitTime<0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("Attack");
                coll2D.enabled = true;
                waitTime = startTime;
            }
        }
        else
        {
            coll2D.enabled = false;
            waitTime -= Time.deltaTime;
        }
        
    }
}
