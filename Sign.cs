using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox = GameObject.Find("Panel");
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if(collision.gameObject.CompareTag("Player")&&collision.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
        {
            dialogBox.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            dialogBox.SetActive(false);
        }
    }
}
