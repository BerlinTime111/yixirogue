using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class zhuan2 : MonoBehaviour
{
    public float coutTime;
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
        if (coutTime >= 75f)
        {
            SceneManager.LoadScene(2);
        }
    }
}
