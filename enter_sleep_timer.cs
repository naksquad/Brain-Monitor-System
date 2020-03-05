
using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class enter_sleep_timer : MonoBehaviour
{
    public static int the_enter_sleep_time;

    public void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
        //Adds a listener to the main input field and invokes a method when the value changes.
        //  mainInputField.onValueChange.AddListener();
        //    mainInputField = GetComponent<Slider>();
        input.onEndEdit.AddListener(SubmitName);
    }

    // Invoked when the value of the text field changes.
    private void SubmitName(string arg0)
    {
        the_enter_sleep_time = System.Convert.ToInt32(arg0); ;
       
    }
}
