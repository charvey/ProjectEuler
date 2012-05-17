using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE
{
    public static class PrimeExtensions
    {
        public static bool IsPrime(this int n)
        {
            if (n == 2) return true;

            var s = (int)Math.Floor(Math.Sqrt(n));

            return Primes(s).All(p => n%p != 0);
        }

        public static bool IsPrime(this uint n)
        {
            if (n == 2) return true;
            if (n % 2 == 0 || n == 1) return false;

            var s = (uint)Math.Floor(Math.Sqrt(n));

            for (uint i = 3; i <= s; i += 2)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        public static bool IsPrime(this long n)
        {
            if (n == 2) return true;
            if(n%2==0||n==1) return false;

            var s = (long)Math.Floor(Math.Sqrt(n));

            for (long i = 3; i <= s; i+=2)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        public static bool IsPrime(this ulong n)
        {
            if (n == 2) return true;
            if (n % 2 == 0 || n == 1) return false;

            var s = (ulong)Math.Floor(Math.Sqrt(n));

            for (ulong i = 3; i <= s; i+=2)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        public static List<int> PrimeList = new List<int> { 2, 3 };
        public static IEnumerable<int> Primes(int n = int.MaxValue)
        {
            foreach (int t in PrimeList)
            {
                if (t > n)
                    yield break;

                yield return t;
            }

            for (int i = PrimeList.Last() + 2; i <= n; i += 2)
            {
                if (i.IsPrime())
                {
                    PrimeList.Add(i);
                    yield return i;
                }
            }
        }
    }
}
