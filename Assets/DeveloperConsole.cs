using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

namespace Console
{
    public class DeveloperConsole : MonoBehaviour
    {
        [SerializeField] public TMP_Text uiCanvas = null;
        [SerializeField] public TMP_InputField inputField = null;

        private readonly IEnumerable<IConsoleCommand> commands;
        public DeveloperConsole(IEnumerable<IConsoleCommand> commands)
        {
            this.commands = commands;
        }

        public void ProcessCommand(string inputValue)
        {
            string[] inputSplit = inputValue.Split(' ');
            string commandInput = inputSplit[0];
            string[] args = inputSplit.Skip(1).ToArray();

            ProcessCommand(commandInput, args);
            inputField.text = string.Empty;
        }

        public void ProcessCommand(string commandInput, string[] args)
        {
            foreach (var command in commands)
            {
                if (!commandInput.Equals(StringComparison.OrdinalIgnoreCase))
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

