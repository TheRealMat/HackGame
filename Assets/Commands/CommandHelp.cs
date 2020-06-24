using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public class CommandHelp : MonoBehaviour
    {
        [CreateAssetMenu(fileName = "New Help Command", menuName = "Commands/Help Command")]
        public class CommandClear : ConsoleCommand
        {
            public override bool Process(string[] args, DeveloperConsole console)
            {
                foreach (ConsoleCommand command in console.commands)
                {
                    console.uiCanvas.text += "\n" + command.CommandWord;
                }

                return true;
            }
        }
    }
}

