namespace FizzBuzz
{
    public class FizzBuzzer
    {
        public static bool IsDivisibleBy(int number, int divisor)
        {
            if (divisor == 0)
                return false;

            return number % divisor == 0;
        }
    }
}
