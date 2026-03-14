using System;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public class CommandProcessor
    {
        private Dictionary<Type, object> _handlesMap = new();

        public void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            _handlesMap[typeof(TCommand)] = handler;
        }

        public bool Process<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (_handlesMap.TryGetValue(typeof(TCommand), out var handle))
            {
                var typedHandler = (ICommandHandler<TCommand>)handle;
                var result = typedHandler.Handle(command);

                return result;
            }

            return false;
        }
    }
}