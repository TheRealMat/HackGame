using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Console
{
    public interface IConsoleCommand
    {
        string CommandWord { get; }
        bool Process(string[] args, DeveloperConsole console);
    }
}

