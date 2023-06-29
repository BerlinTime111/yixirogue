using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindWithTag("Player");
        DestroyImmediate(go);
        GameObject lan = GameObject.Find("Canvas1");
        DestroyImmediate(lan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
