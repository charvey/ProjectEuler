using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem187:Problem
    {
        public override int Number
        {
            get { return 187; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(30)==10);

            return S(100000000);
        }

        public uint S(int n)
        {
            var p = Primes(n / 2);

            uint count = 0;

            for (var a = 0; a < p.Length; a++)
            {
                if(p[a]*p[a]>=n)
                    break;

                for (var b = a; b < p.Length; b++)
                {
                    if (p[a]*p[b] >= n)
                        break;
                    else
                       count++;
                }
            }

            return count;
        }

        public uint[] Primes(int n)
        {
            var sieve = new bool[n+1];
            sieve[0] = false;
            sieve[1] = false;
            for(int i=2;i<=n;i++) sieve[i] = true;

            for(int i=2;i<=n;i++)
            {
                if(sieve[i])
                {
                    for(int j=i+i;j<=n;j+=i)
                    {
                        sieve[j] = false;
                    }
                }
            }

            return sieve.Select((prime, i) => (uint)(prime ? i : 0)).Where(i => i > 0).ToArray();
        }
    }
}
