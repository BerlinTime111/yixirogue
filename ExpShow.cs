using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpShow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TMP_Text>().text = player.GetComponent<Attribute>().exp.ToString();
    }
}
