using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAttack : MonoBehaviour
{
    public float time;
    public float startTime;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(time>0)
        {
            if (collision.CompareTag("Player"))
            {
                time -= Time.deltaTime;
            }
                
        }
        else
        {
            if(collision.CompareTag("Player"))
            {
                collision.GetComponent<Attribute>()?.TakeDamage(this);
            }
            time = startTime;
        }
        
    }

}
