using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openMap : MonoBehaviour
{
    public GameObject Map;
    private bool map = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            map = !map;
            Map.SetActive(map);

        }
    }
}
