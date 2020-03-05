using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class ENTER_Control_dect : MonoBehaviour
{
    public static int the_ENTER_Control_dect;

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
        the_ENTER_Control_dect = System.Convert.ToInt32(arg0);

    }
}
