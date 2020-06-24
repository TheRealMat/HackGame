using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Console
{
    public class SelectInput : MonoBehaviour
    {
        // this is kind of bad. maybe i can override inputfield instead
        // overriding inputfield turned out to be a pain in the ass

        [SerializeField] private TMP_InputField inputField = null;
        [SerializeField] private TMP_Text text = null;
        [SerializeField] private DeveloperConsole console = null;

        private void Start()
        {
            SelectField();
        }
        public void SelectField()
        {
            inputField.ActivateInputField();
        }
        private void Update()
        {
            if (inputField.IsActive() && inputField.text.Length != 0 && Input.GetKeyDown(KeyCode.Return))
            {
                console.ProcessCommand(text.text);
            }
        }
    }
}