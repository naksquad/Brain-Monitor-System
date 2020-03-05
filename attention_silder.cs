using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attention_silder : MonoBehaviour
{
    public Slider ATTSlider;
    public static float attention_speed_level = 0;
    // Start is called before the first frame update
    void Start()
    {
        ATTSlider = GetComponent<Slider>();
        // ATTSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {

    }
    // Update is called once per frame
    void Update()
    {
        attention_speed_level = ATTSlider.value;
        Meter_aten.Meter_aten_txt.text = ((ATTSlider.value).ToString());
    }

}

