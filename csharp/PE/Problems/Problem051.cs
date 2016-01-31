using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;

namespace PE.Problems
{
    class Problem051:Problem
    {
        public override int Number
        {
            get { return 051; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(GroupOf(6) == 13);
            Debug.Assert(GroupOf(7) == 56003);

            return GroupOf(8);
        }

        private int GroupOf(int n)
        {


            foreach (int p in PrimeExtensions.Primes().Skip(4))
            {
                int[] digits = p.Digits().ToArray();
                int permutations = (int)Math.Pow(2, p.DigitCount());

                for (int mask = 1; mask <= permutations; mask++)
                {
                    int B = 0, I = 0;


                }
            }

            return 0;
        }
    }
}
