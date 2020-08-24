using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoProblem1();
                DoProblem2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled Error!");
                Console.WriteLine(ex.Message);
            }
        }

        static void DoProblem2()
        {
            Console.WriteLine("Problem 2 goes here");
        }

        static void DoProblem1()
        {
            Console.WriteLine("Feed me some numbers!");

            const int numberOfNumbersToAskFor = 5;
            int[] numbers = AskForNumbers(numberOfNumbersToAskFor);

            PrintNumbers(numbers);
        }

        static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        static Random random = new Random();

        static int[] AskForNumbers(int numberOfNumbersToAskFor)
        {
            int[] numbers = new int[numberOfNumbersToAskFor];
            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    numbers[i] = Convert.ToInt32(Console.ReadLine());
                    // numbers[i] = int.Parse(Console.ReadLine());
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("Invalid number! Picking random one instead.");
                    numbers[i] = random.Next(5, 10);
                }
                catch (OverflowException oex)
                {
                    Console.WriteLine(oex.Message);
                    Console.WriteLine("Please try again!");

                    // goto would work here, but let's just decrement i to try again
                    i--;
                }
            }

            return numbers;
        }
    }
}
