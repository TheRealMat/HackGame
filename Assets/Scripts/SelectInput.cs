using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

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
            // check if i'm pressing something instead. then i can check which button it is with a switch

            if (inputField.IsActive() && inputField.text.Length != 0 && Input.GetKeyDown(KeyCode.Return))
            {
                console.ProcessCommand(text.text);
            }

            else if (inputField.IsActive() && inputField.text.Length != 0 && Input.GetKeyDown(KeyCode.Tab))
            {
                string[] textArray = Regex.Split(inputField.text, @"( )");
                // show arguments if previous index is a command

                foreach (ConsoleCommand command in console.commandsList.commands)
                {
                    if (command.CommandWord.StartsWith(textArray[textArray.Length - 1]))
                    {
                        // show commands if multiple match

                        textArray[textArray.Length - 1] = command.CommandWord;
                        inputField.text = string.Concat(textArray);

                        inputField.caretPosition = inputField.text.Length;
                        return;
                    }
                }

            }
        }
    }
}