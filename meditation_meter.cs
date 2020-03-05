using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class meditation_meter : MonoBehaviour
{
    public static Text Meter_meditation_txt;

    // Start is called before the first frame update
    void Start()
    {
        Meter_meditation_txt = GetComponent<Text>();

    }
}
