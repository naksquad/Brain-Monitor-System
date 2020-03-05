using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;


public class Head_scr : MonoBehaviour
{
    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        _text.text = ((PortS.brain_level_headlevel).ToString());
    }
}
