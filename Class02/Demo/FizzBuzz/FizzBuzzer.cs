namespace FizzBuzz
{
    public class FizzBuzzer
    {
        // but print Fizz if a multiple of 3
        //     print Buzz if a multiple of 5
        //     print FizzBuzz if a multiple of both
        //     otherwise the number
        public static string Convert(int number)
        {
            if (IsDivisibleBy(number, 3) && IsDivisibleBy(number, 5))
                return "FizzBuzz";

            if (IsDivisibleBy(number, 3))
                return "Fizz";

            if (IsDivisibleBy(number, 5))
                return "Buzz";

            return number.ToString();
        }

        public static bool IsDivisibleBy(int number, int divisor)
        {
            if (divisor == 0)
                return false;

            return number % divisor == 0;
        }
    }
}
