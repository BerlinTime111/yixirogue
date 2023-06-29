using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioSource bgmcontorll;
    public GameObject menuList;
    public bool key = true;
    void Start()
    {
           }

   
    void Update()
    {
        if (key)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(true);
                key = false;
                Time.timeScale = 0;// ±º‰±∂ ˝
                //bgmcontorll.Pause();//“Ù¿÷‘›Õ£
            }

        }
        else if (!key)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(false);
                key = true;
                Time.timeScale = 1;
                //bgmcontorll.Play();
            }
        }

    }
   public void GoBack()
    {
        GameObject go = GameObject.FindWithTag("Player");
        DestroyImmediate(go);
        GameObject lan = GameObject.Find("Canvas1");
        DestroyImmediate(lan);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        //SceneManager.LoadScene(0);
        GameObject go = GameObject.FindWithTag("Player");
        DestroyImmediate(go);
        GameObject lan = GameObject.Find("Canvas1");
        DestroyImmediate(lan);
        SceneManager.LoadScene(1);
        key = true;
        Time.timeScale = 1;
        bgmcontorll.Play();
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
 #else
        Application.Quit();
#endif

    }
}
