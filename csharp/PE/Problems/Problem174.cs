using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem174:Problem
    {
        public override int Number
        {
            get { return 174; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(L(8) == 1);
            Debug.Assert(L(32) == 2);
            Debug.Assert(N(15) == 832);

            return Enumerable.Range(1, 10).Sum(n => N(n));
        }

        private List<int> _n;
        int N(int n)
        {
            if(_n==null)
                _n = Enumerable.Range(1, 1000000).AsParallel().Select(L).ToList();

            return _n.Count(t => t == n);
        }

        int L(int n)
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
