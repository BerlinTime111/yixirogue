using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceredtea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerContorl>().speed += 0.05f;
        }
    }
}
