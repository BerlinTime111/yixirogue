using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI���")]
    public Text TextLable;
    //public Image FaceImage;

    [Header("�ı����")]
    public TextAsset TextFile;
    public int index;

    public float textSpeed;
    bool textfinish;
    List<string> textlist = new List<string>();

    void Awake ()
    {
        GetTextFormFile(TextFile);//��ȡ
        //TextLable.text = textlist[index];
        //index++;
    }


    private void OnEnable()
    {

        //    TextLable.text = textlist[index];
        //    index++;
        textfinish = true;
        StartCoroutine(SetTextUI());

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && index == textlist.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space)&&textfinish)
        {
            //TextLable.text = textlist[index];
            //index++;
            StartCoroutine(SetTextUI());
        }
    }


    void GetTextFormFile(TextAsset file)//��ȡ
    {
        textlist.Clear();//���
        index = 0;

        var lineData = file.text.Split('\n');

        foreach(var line in lineData)
        {
            textlist.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textfinish = false;
        TextLable.text = ""; 
        for (int i = 0; i< textlist[index].Length; i++)
        {
            TextLable.text += textlist[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textfinish = true;
        index++;
    }
}
