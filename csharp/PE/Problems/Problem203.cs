using System;
using System.Collections.Generic;
using System.Linq;

namespace PE.Problems
{
    class Problem203:Problem
    {
        public override int Number
        {
            get { return 203; }
        }

        public override ValueType Solve()
        {
            var numbers = new HashSet<ulong>(new ulong[] {1});
            const int ROWS = 51;

            ulong[] prev;
            ulong[] next = { 1 };

            for(int size=2;size<=ROWS;size++)
            {
                prev = next;

                next = new ulong[size];
                next[0] = next[size - 1] = 1;

                for(int i=1;i<size-1;i++)
                {
                    next[i] = prev[i-1] + prev[i];
                    numbers.Add(next[i]);
                }
            }

            var candidates = numbers.Where(n => n%4 != 0).OrderBy(n => n).ToList();
            
            foreach(ulong prime in PrimeExtensions.Primes((int)Math.Floor(Math.Sqrt(candidates.Last()))))
            {
                candidates = candidates.Where(n => n%(prime*prime) != 0).ToList();
            }

            return candidates.Sum(n=>(long)n);
        }
    }
}
