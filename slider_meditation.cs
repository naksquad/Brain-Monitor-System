using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider_meditation : MonoBehaviour
{
    public Slider MEd_Slider;
    public static float Meditationn_speed_level = 0;
    // Start is called before the first frame update
    void Start()
    {
        MEd_Slider = GetComponent<Slider>();
        // ATTSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Meditationn_speed_level = MEd_Slider.value;
        meditation_meter.Meter_meditation_txt.text = ((MEd_Slider.value).ToString());
    }

}

