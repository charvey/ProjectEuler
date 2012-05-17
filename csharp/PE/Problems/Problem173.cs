using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem173:Problem
    {
        public override int Number
        {
            get { return 173; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(Sum(100) == 41);

            return Sum(1000000);
        }

        int Sum(int n)
        {
            return Enumerable.Range(1, n).Select(LaminaeCount).Sum();
        }

        int LaminaeCount(int n)
        {
            int c = 0;

            if (n < 8 || n % 4 != 0)
                return 0;

            for (int h = 1; 4 * h + 4 <= n; h++)
                for (int w = 1; w*(h + w) <= n/4; w++)
                    if (w*(h + w) == n/4)
                        c++;

            return c;
        }
    }
}
