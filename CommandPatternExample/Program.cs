using System;
using System.Collections.Generic;

namespace CommandPatternExample
{
    // The 'Command' interface — declares a method for executing a command
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    // The 'Receiver' class — knows how to perform the work needed to carry out a request
    class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light is ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is OFF");
        }
    }

    // The 'ConcreteCommand' class — binds a Receiver to an action
    class TurnOnLightCommand : ICommand
    {
        private Light _light;

        public TurnOnLightCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }

        public void Undo()
        {
            _light.TurnOff();
        }
    }

    // Another ConcreteCommand
    class TurnOffLightCommand : ICommand
    {
        private Light _light;

        public TurnOffLightCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }

        public void Undo()
        {
            _light.TurnOn();
        }
    }

    // The 'Invoker' class — asks the command to carry out the request
    class RemoteControl
    {
        private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            if (_commandHistory.Count > 0)
            {
                ICommand lastCommand = _commandHistory.Pop();
                lastCommand.Undo();
            }
            else
            {
                Console.WriteLine("No commands to undo.");
            }
        }
    }

    // The 'Client' — creates and configures commands and receivers
    internal class Program
    {
        static void Main(string[] args)
        {
            // Receiver: the actual object that will perform the actions
            Light livingRoomLight = new Light();

            // Concrete Commands
            ICommand turnOn = new TurnOnLightCommand(livingRoomLight);
            ICommand turnOff = new TurnOffLightCommand(livingRoomLight);

            // Invoker: triggers commands
            RemoteControl remote = new RemoteControl();

            // Execute some commands
            remote.ExecuteCommand(turnOn);
            remote.ExecuteCommand(turnOff);

            // Undo last command
            remote.UndoLastCommand();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
