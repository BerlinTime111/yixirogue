using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAttack : MonoBehaviour
{
    public int damage;
    public float attackRange;
    public float attackRate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        this.GetComponent<Attribute>().TakeDamage(collision.GetComponent<Attack>());
    }
}
