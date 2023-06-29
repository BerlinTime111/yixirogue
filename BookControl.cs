using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookControl : MonoBehaviour
{
    public bool ishurt;
    public bool isDead;
    public GameObject drop;
    public float dropRate;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gethurt()
    {
        ani.SetTrigger("isHurt");
        
    }
    public void playDead()
    {
        Destroy(gameObject, 0.1f);
        int i=Random.Range(0, 100);
        if(i<dropRate)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
        }
        GameObject gb = GameObject.Find("Player");
        gb.GetComponent<Attribute>().ExpUp();
    }
    public void getDead()
    {
        isDead = true;
    }
}
