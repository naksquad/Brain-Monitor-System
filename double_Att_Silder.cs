using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class double_Att_Silder : MonoBehaviour
{
    public Slider double_ATTSlider;
    public static float double_attention_speed_level = 0;
    // Start is called before the first frame update
    void Start()
    {
        double_ATTSlider = GetComponent<Slider>();
        
    }
    public void ValueChangeCheck()
    {

    }
    // Update is called once per frame
    void Update()
    {
        double_attention_speed_level = double_ATTSlider.value;
        double_Att_Range.double_Att_Range_txt.text = ((double_ATTSlider.value).ToString());
    }

}

