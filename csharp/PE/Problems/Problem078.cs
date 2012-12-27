using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PE.Problems
{
    class Problem078:Problem
    {
        public override int Number
        {
            get { return 078; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(P(1) == 1);
            Debug.Assert(P(2) == 2);
            Debug.Assert(P(3) == 3);
            Debug.Assert(P(4) == 5);
            Debug.Assert(P(5) == 7);

            return Enumerable.Range(1, 1000000).Select(i => P(i)).First(p => p % 1000000 == 0);
        }

        protected long P(int p)
        {
            return P(p, p);
        }

        protected long P(int p, int m)
        {
            if (p == 0)
            {
                return 1;
            }

            long s = 0;
            for (int n = m; n >= 1; n--)
            {
                s += P(p - n, Math.Min(p - n, n));
            }
            return s;
        }
    }
}
