using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthControl : MonoBehaviour
{
    Slider sl;
    public GameObject player;
    Attribute at;
    // Start is called before the first frame update
    void Start()
    {
        sl = GetComponent<Slider>();
        at = player.GetComponent<Attribute>();
    }

    // Update is called once per frame
    void Update()
    {
        sl.value = at.currentBlood / at.maxBlood;
    }
}
