using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int attack;
    public GameObject explosionPrefab;
    new private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    void Update()
    {

    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    //    GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
    //    exp.transform.position = transform.position;

    //    // Destroy(gameObject);
    //    ObjectPool.Instance.PushObject(gameObject);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        if(exp!=null)
        {
            exp.transform.position = transform.position;
        }
        // Destroy(gameObject);
        ObjectPool.Instance.PushObject(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")||collision.CompareTag("book")||collision.CompareTag("boss"))
        {
            collision.GetComponent<Attribute>()?.TakeDamage(this);
        }
    }
}
