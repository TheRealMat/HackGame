using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

namespace Console
{
    public class DeveloperConsole : MonoBehaviour
    {
        [SerializeField] public TMP_Text uiCanvas = null;
        [SerializeField] public TMP_InputField inputField = null;
        [SerializeField] public Node currentNode = null;



        // ------ this needs to be rethought ------ //

        public CommandsList commandsList;
        public IEnumerable<IConsoleCommand> commands { get; set; }
        //public DeveloperConsole(IEnumerable<IConsoleCommand> commands)
        //{
        //    this.commands = commandsList.commands;
        //}
        private void Start()
        {
            this.commands = commandsList.commands;
        }
        // ------ this needs to be rethought ------ //




        public void ProcessCommand(string inputValue)
        {
            // there is a weird white space that i'm replacing
            inputValue = Regex.Replace(inputValue, "​", "");

            string[] inputSplit = inputValue.Split(' ');
            string commandInput = inputSplit[0];
            string[] args = inputSplit.Skip(1).ToArray();



            uiCanvas.text += "\n" + inputValue;
            ProcessCommand(commandInput, args);
            inputField.text = string.Empty;

        }

        public void ProcessCommand(string commandInput, string[] args)
        {
            foreach (var command in commands)
            {
                if (!commandInput.Equals(command.CommandWord, StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                if (command.Process(args, this))
                {
                    return;
                }
            }
        }
    }

}

