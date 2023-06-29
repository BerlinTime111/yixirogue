using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerContorl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    Vector2 movement;
    Attribute at;
    public float speed;
    public bool isHurt;
    public float hurtForce;
    public bool isDead;
    public bool isAttack;
    public GameObject[] guns;
    public int gunNum;
    // Start is called before the first frame update
    void Start()
    {
        guns[1].SetActive(true);
        guns[0].SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        at = GetComponent<Attribute>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchGun();
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement.x != 0)
            {
                transform.localScale = new Vector3(movement.x, 1, 1);
                guns[0].transform.localScale= new Vector3(movement.x, 1, 1);
                guns[1].transform.localScale = new Vector3(movement.x, 1, 1);
        }
        SwitchAnim();
        //Attack();

    }
    private void FixedUpdate()
    {
        if (!isHurt)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    public void SwitchAnim()
    {
        anim.SetFloat("speed", movement.magnitude);
        anim.SetFloat("currentBlood",at.currentBlood);
        anim.SetBool("isDead", isDead);
       
    }
    public void PlayHurt()
    {
        anim.SetTrigger("hurt");
    }
    public void gethurt(Transform attacker)
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(transform.position.x-attacker.position.x, transform.position.y-attacker.position.y).normalized;//获得反弹方向
        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);//施加反弹力
    }
    public void PlayerDead()
    {
        isDead = true;
        speed = 0;
    }
    void SwitchGun()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            guns[gunNum].SetActive(false);
            if (--gunNum < 0)
            {
                gunNum = guns.Length - 1;
            }
            guns[gunNum].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            guns[gunNum].SetActive(false);
            if (++gunNum > guns.Length - 1)
            {
                gunNum = 0;
            }
            guns[gunNum].SetActive(true);
        }
    }
}
    //public void Attack()
    //{
    //    if(Input.GetKeyDown(KeyCode.F))
    //    {
    //        anim.SetTrigger("Attack");
    //    }
    //}
    
