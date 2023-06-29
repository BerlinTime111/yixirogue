using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarControl : MonoBehaviour
{
    public GameObject player;
    public Slider sl;
    // Start is called before the first frame update
    void Start()
    {
        sl = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        sl.value = player.GetComponent<Attribute>().exp / player.GetComponent<Attribute>().level_exp[player.GetComponent<Attribute>().level];
    }
}
