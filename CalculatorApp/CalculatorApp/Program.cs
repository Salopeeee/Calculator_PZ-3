using CalculatorLibrary;
using System;
using static CalculatorLibrary.CalculatorCommands;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ініціалізація калькулятора і інвокера
            Calculator calculator = new Calculator();
            CommandInvoker invoker = new CommandInvoker(calculator);

            // Створення команд 12 + 2 * ((3 * 4) + (10 / 5)) = 40
            ICommand addCommand1 = new AddCommand(12.0);
            ICommand addCommand2 = new AddCommand(2.0);
            ICommand multiplyCommand1 = new MultiplyCommand(3.0);
            ICommand parenthesis1 = new ParenthesisOpenCommand('(');
            ICommand parenthesis2 = new ParenthesisOpenCommand('(');
            ICommand multiplyCommand2 = new MultiplyCommand(4.0);
            ICommand parenthesis3 = new ParenthesisCloseCommand(')');
            ICommand addCommand3 = new AddCommand(10.0);
            ICommand parenthesis4 = new ParenthesisOpenCommand('(');
            ICommand divideCommand1 = new DivideCommand(5.0);
            ICommand parenthesis5 = new ParenthesisCloseCommand(')');
            ICommand parenthesis6 = new ParenthesisCloseCommand(')');

            // Додавання команд до інвокера
            invoker.StoreCommand(addCommand1);
            invoker.StoreCommand(addCommand2);
            invoker.StoreCommand(multiplyCommand1);
            invoker.StoreCommand(parenthesis1);
            invoker.StoreCommand(parenthesis2);
            invoker.StoreCommand(multiplyCommand2);
            invoker.StoreCommand(parenthesis3);
            invoker.StoreCommand(addCommand3);
            invoker.StoreCommand(parenthesis4);
            invoker.StoreCommand(divideCommand1);
            invoker.StoreCommand(parenthesis5);
            invoker.StoreCommand(parenthesis6);

            // Початок послідовності обчислень
            calculator.BeginSequence();

            // Виконання всіх команд
            invoker.ExecuteAll();

            // Завершення послідовності обчислень і виведення результату
            Console.WriteLine($"Result: {calculator.EndSequence()}");
            Console.ReadKey();
        }
    }
}
