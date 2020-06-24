using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Console
{
    [CreateAssetMenu(fileName = "New Connect Command", menuName = "Commands/Connect Command")]
    public class CommandConnect : ConsoleCommand
    {
        public override bool Process(string[] args, DeveloperConsole console)
        {
            if (args.Length == 1)
            {
                foreach (Node node in console.currentNode.connectedNodes)
                {
                    if (node.nodeIP == args[0])
                    {
                        console.currentNode = node;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
