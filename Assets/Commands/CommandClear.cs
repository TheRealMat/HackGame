using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Console
{
    [CreateAssetMenu(fileName = "New Clear Command", menuName = "Commands/Clear Command")]
    public class CommandClear : ConsoleCommand
    {
        public override bool Process(string[] args, DeveloperConsole console)
        {
            console.uiCanvas.text = string.Empty;

            return true;
        }
    }
}

