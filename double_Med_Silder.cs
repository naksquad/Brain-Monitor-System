using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class double_Med_Silder : MonoBehaviour
{
    public Slider double_MED_Slider;
    public static float double_Meditation_speed_level = 0;
    // Start is called before the first frame update
    void Start()
    {
        double_MED_Slider = GetComponent<Slider>();
        // ATTSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {

    }
    // Update is called once per frame
    void Update()
    {
        double_Meditation_speed_level = double_MED_Slider.value;
        double_Med_Range.double_Med_Range_txt.text = ((double_MED_Slider.value).ToString());
    }

}

