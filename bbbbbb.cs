using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbbbbb : MonoBehaviour
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
            collision.transform.GetChild(3).GetComponent<Shotgun>().bulletNum += 1;
        }
    }
}
