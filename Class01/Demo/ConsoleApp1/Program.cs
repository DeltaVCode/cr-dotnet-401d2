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
            int[] numbers = AskForNumbers(numberOfNumbersToAskFor);

            PrintNumbers(numbers);
        }

        private static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        private static int[] AskForNumbers(int numberOfNumbersToAskFor)
        {
            int[] numbers = new int[numberOfNumbersToAskFor];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
                // numbers[i] = int.Parse(Console.ReadLine());
            }

            return numbers;
        }
    }
}
