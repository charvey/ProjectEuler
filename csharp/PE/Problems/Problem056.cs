using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace PE.Problems
{
    class Problem056:Problem
    {
        public override int Number
        {
            get { return 056; }
        }

        public override ValueType Solve()
        {
            return Enumerable.Range(1, 100).SelectMany(a => Enumerable.Range(1, 100).Select(b => BigInteger.Pow(a, b))).Max(n => DigitSum(n));
        }

        public int DigitSum(BigInteger n)
        {
            return n == 0 ? 0 : DigitSum(n/10) + (int) (n%10);
        }
    }
}
