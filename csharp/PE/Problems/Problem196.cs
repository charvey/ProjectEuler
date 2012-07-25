using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem196:Problem
    {
        public override int Number
        {
            get { return 196; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(8) == 60);
            Debug.Assert(S(9) == 37);
            Debug.Assert(S(10000) == 950007619);

            return S(5678027) + S(7208785);
        }

        private ulong S(ulong n)
        {
            ulong sum = 0;
            uint start = (uint)((n * n + n) / 2 - n + 1);
            uint currPrime = 3;
            bool[] sieve = new bool[n];
            uint offset = 0;

            for (uint i = (start % 2 == 0 ? 1u : 0u); i < n; i += 2)
                sieve[i] = true;

            for (offset = 0; offset < n; offset++)
            {
                while (sieve[offset] && (start + offset) % currPrime == 0 && currPrime < (start + offset))
                {
                    for (uint i = start + offset; i < n; i += currPrime)
                        sieve[i] = false;

                    currPrime = nextPrime(currPrime);
                }

                if (currPrime == start + offset || (start+offset).IsPrime())
                {
                    if ((
                            (offset > 0 && (start + offset - n + 0).IsPrime() ? 1 : 0) +
                            (offset < n - 1 && (start + offset - n + 1).IsPrime() ? 1 : 0) +
                            (offset < n - 2 && (start + offset - n + 2).IsPrime() ? 1 : 0) +
                            (offset > 0 && (start + offset + n - 1).IsPrime() ? 1 : 0) +
                            ((start + offset + n + 0).IsPrime() ? 1 : 0) +
                            ((start + offset + n + 1).IsPrime() ? 1 : 0)
                        ) >= 2)
                    {
                        sum += start + offset;
                    }
                }
            }

            return sum;
        }

        private uint nextPrime(uint currPrime)
        {
            do
            {
                currPrime += 2;
            } while (!currPrime.IsPrime());

            return currPrime;
        }
    }
}
