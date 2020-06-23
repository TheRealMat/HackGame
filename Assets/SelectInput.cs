using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectInput : MonoBehaviour
{
    // this is kind of bad. maybe i can override inputfield instead

    [SerializeField] private TMP_InputField inputField;

    private void Start()
    {
        SelectField();
    }
    public void SelectField()
    {
        inputField.ActivateInputField();
    }
}
