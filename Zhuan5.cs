using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Zhuan5 : MonoBehaviour
{
    private float coutTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coutTime += Time.deltaTime;
        if (coutTime >= 10f)
        {
            SceneManager.LoadScene(10);
        }
    }
}
