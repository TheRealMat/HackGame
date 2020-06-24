﻿using System;
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


        // ------ this needs to be rethought ------ //

        public CommandsList commandsList;
        private IEnumerable<IConsoleCommand> commands;
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
            string[] inputSplit = inputValue.Split(' ');
            string commandInput = inputSplit[0];
            string[] args = inputSplit.Skip(1).ToArray();

            // there is a weird white space that i'm replacing
            commandInput = Regex.Replace(commandInput, "​", "");

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

