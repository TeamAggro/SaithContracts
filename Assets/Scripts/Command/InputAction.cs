using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Aggro.Command
{
    public class InputAction : Command
    {

        public InputAction(Action _command) : base(_command) { }

        public override void Execute()
        {
            if (command != null)
            {
                command();
            }
            else {
                throw new System.ArgumentException("No method");
            }
        }
    }
}
