using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Zhuan4 : MonoBehaviour
{
    public float coutTime=0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoutTime();
    }
    private void CoutTime()
    {
        coutTime += Time.deltaTime;
        if (coutTime >= 8f)
        {
            SceneManager.LoadScene(8);
        }
    }
}
