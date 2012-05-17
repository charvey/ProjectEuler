using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace PE.Problems
{
    class Problem069:Problem
    {
        public override int Number
        {
            get { return 069; }
        }

        private const int N = 1000000;
        private static readonly int[] Totients = new int[N+1];
        private static int Remaining
        {
            get { return Totients.Skip(2).Count(i => i == 0); }
        }

        public override ValueType Solve()
        {
            Enumerable.Range(2, N - 1).AsParallel().Count(Compute);

            var ratios = Totients.Select((t, n) => t>0?((double) n)/t:double.MinValue).ToList();
            var max = ratios.Max();
            return ratios.IndexOf(max);
        }

        private bool Compute(int n)
        {
            if (Totients[n] != 0)
                return true;

            int t = Totients[n] = Totient(n);

            if (2 * n <= N)
            {
                Totients[2*n] = (2 - n%2)*t;

                for (var p = 4; p*n <= N; p *= 2)
                    Totients[n*p] = t*p;

                for (long p = n; p*n <= N; p *= n)
                    Totients[p*n] = (int) p*t;
            }

            return true;
        }

        private int Totient(int n)
        {
            return Enumerable.Range(1, n - 1).AsParallel().Count(i => IsCoprime(n, i));
        }

        private bool IsCoprime(int a, int b)
        {
            int t;
            while (b>0)
            {
                t = a%b;
                a = b;
                b = t;
            }
            return a==1;
        }

        private int gcd(int a,int b)
        {
            return b == 0 ? a : gcd(b, a%b);
        }
    }
}
