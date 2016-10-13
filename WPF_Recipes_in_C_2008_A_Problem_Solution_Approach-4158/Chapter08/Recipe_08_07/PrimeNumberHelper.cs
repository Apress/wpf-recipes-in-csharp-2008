using System;

namespace Recipe_08_07
{
    public static class PrimeNumberHelper
    {
        /// <summary>
        /// Return true if the specified number is a prime
        /// </summary>
        public static bool IsPrime(long number)
        {
            for(long i = 2; i <= Math.Sqrt(number); i++)
            {
                if(number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}