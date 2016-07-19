using UnityEngine;
using System.Collections;
using System;

namespace Aggro.Command
{
    public abstract class Command
    {
        protected Action command;

        public Command(Action _command)
        {
            command = _command;
        }

        public abstract void Execute();
    }
}
