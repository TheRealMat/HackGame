using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    [CreateAssetMenu(fileName = "New Scan Command", menuName = "Commands/Scan Command")]
    public class CommandScan : ConsoleCommand
    {
        public override bool Process(string[] args, DeveloperConsole console)
        {

            foreach (Node node in console.currentNode.connectedNodes)
            {
                console.uiCanvas.text += "\n" + $"{node.nodeName} {node.nodeIP}";
            }


            return true;
        }
    }
}
