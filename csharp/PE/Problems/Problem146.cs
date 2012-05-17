using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    internal class Problem146 : Problem
    {
        public override int Number
        {
            get { return 146; }
        }

        public override ValueType Solve()
        {
            const int TestInput = 1000000;
            const int TestAnswer = 1242490;
            const int RealInput = 150000000;

            Debug.Assert(S(TestInput) == TestAnswer);
            return S(RealInput);
        }

        public ulong S(int N)
        {
            var nPos = Enumerable.Range(1, N).Select(i => (ulong) i).Where(i => (i*i)%2 == 0);

            ulong s = 0;

            nPos = nPos.Where(i => (i*i + 1).IsPrime()).ToList();

            foreach(var n in nPos)
            {
                if(Valid(n))
                {
                    s += n;
                }
            }

            return s;
        }

        public bool Valid(ulong n)
        {
            ulong n2 = n*n;

            int pi = iPrime(n2 + 01);

            if(pi==0)
                return false;

            return iPrime(n2 + 03) == pi + 1 && iPrime(n2 + 07) == pi + 2 &&
                   iPrime(n2 + 09) == pi + 3 && iPrime(n2 + 13) == pi + 4 && iPrime(n2 + 27) == pi + 5;
        }

        public List<ulong> _Primes = new List<ulong> { 2 };
        public int iPrime(ulong n)
        {
            var sieve = new bool[n + 1];
            sieve[0] = false;
            sieve[1] = false;
            for (ulong i = 2; i <= n; i++) sieve[i] = true;

            for (ulong i = _Primes.Last() + 1; i <= n; i++)
            {
                if (sieve[i])
                {
                    _Primes.Add(i);
                    for (ulong j = i + i; j <= n; j += i)
                    {
                        sieve[j] = false;
                    }
                }
            }

            return _Primes.IndexOf(n) + 1;
        }
    }
}
