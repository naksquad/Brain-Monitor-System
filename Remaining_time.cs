using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Remaining_time : MonoBehaviour
{
    public static Text Remaining_time_timer;

    // Start is called before the first frame update
    void Start()
    {
        Remaining_time_timer = GetComponent<Text>();

    }
}
