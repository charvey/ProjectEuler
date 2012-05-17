using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PE.Problems
{
    class Problem271:Problem
    {
        public override int Number
        {
            get { return 271; }
        }

        public override ValueType Solve()
        {
            const long test = 91;
            const long actual = 13082761331670030;

            return S(test);
        }

        public long S(long n)
        {
            return C(n).Sum();
        }

        protected IEnumerable<long> C(long n)
        {
            for (long x = 2; (x*x) < n; x++)
            {
                if (n % (x*x) == 0 && (n / (x*x)).IsPrime())
                    yield return (n / (x * x));
            }
        }
    }
}
