using CalculatorLibrary;
using System.Collections.Generic;

namespace CalculatorApp
{
    public class CommandInvoker
    {
        private List<ICommand> _commands = new List<ICommand>();
        private ICalculatorCommands _calculator;

        public CommandInvoker(ICalculatorCommands calculator)
        {
            _calculator = calculator;
        }

        public void StoreCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public double ExecuteAll()
        {
            _calculator.BeginSequence();

            foreach (var command in _commands)
            {
                command.Execute(_calculator);
            }

            return _calculator.EndSequence();
        }
    }
}
