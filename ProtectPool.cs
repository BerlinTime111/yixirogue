using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectPool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("ObjectPool")!=null)
        {
            DontDestroyOnLoad(GameObject.Find("ObjectPool"));
        }
    }
}
