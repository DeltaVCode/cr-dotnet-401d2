using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DoProblem1();
        }

        private static void DoProblem1()
        {
            Console.WriteLine("Feed me some numbers!");

            const int numberOfNumbersToAskFor = 5;
            string[] numbers = AskForNumbers(numberOfNumbersToAskFor);

            PrintNumbers(numbers);
        }

        private static void PrintNumbers(string[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        private static string[] AskForNumbers(int numberOfNumbersToAskFor)
        {
            string[] numbers = new string[numberOfNumbersToAskFor];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Console.ReadLine();
            }

            return numbers;
        }
    }
}
