using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Sleep : MonoBehaviour
{
    public Slider sleep_Slider;
    public static float sleep_speed_level = 0;
    // Start is called before the first frame update
    void Start()
    {
        sleep_Slider = GetComponent<Slider>();
        // ATTSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {

    }
    // Update is called once per frame
    void Update()
    {
        sleep_speed_level = sleep_Slider.value;
        sleep_meter.Meter_sleep_txt.text = ((sleep_Slider.value).ToString());
    }

}

