using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class sleep_meter : MonoBehaviour
{
    public static Text Meter_sleep_txt;

    // Start is called before the first frame update
    void Start()
    {
        Meter_sleep_txt = GetComponent<Text>();

    }
}
