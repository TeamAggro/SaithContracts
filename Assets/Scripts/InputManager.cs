using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Aggro.Command
{
    public class InputManager
    {

        private static Dictionary<string, InputAction> commandList;

        public InputManager()
        {
            commandList = new Dictionary<string, InputAction>();
        }

        public void AddControl(string _cmdName, System.Action _cmd)
        {
            if (commandList.ContainsKey(_cmdName))
            {
                commandList[_cmdName] = new InputAction(_cmd);
            }
            else
            {
                commandList.Add(_cmdName, new InputAction(_cmd));
            }
        }

        public void ResetControls()
        {
            commandList.Clear();
        }

        public void ExecuteCommand(string _cmdName)
        {
            if (commandList.ContainsKey(_cmdName))
            {
                commandList[_cmdName].Execute();
            }
            else
            {
                throw new System.ArgumentException("No such command");
            }
        }

    }
}
