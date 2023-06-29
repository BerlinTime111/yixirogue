using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class zhuan : MonoBehaviour
{
    public float countTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
    }
    void CountTime()
    {
        countTime += Time.deltaTime;
        if(countTime>11f)
        {
            SceneManager.LoadScene(3);
        }
    }
}
