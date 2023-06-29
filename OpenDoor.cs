using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject upDoor;
    public GameObject downDoor;
    // Start is called before the first frame update
    void Start()
    {
        leftDoor.GetComponent<BoxCollider2D>().enabled = false;
        rightDoor.GetComponent<BoxCollider2D>().enabled = false;
        upDoor.GetComponent<BoxCollider2D>().enabled = false;
        downDoor.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
