using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem373:Problem
    {
        public override int Number
        {
            get { return 373; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(100) == 4950);
            Debug.Assert(S(1200) == 1653605);

            return Enumerable.Range(1, 10000000).Select(S).Sum();
        }

        public int S(int n)
        {
            if (n == 0)
                return 0;

            var pointCount = 0;

            for(var x=0;x<n;x++)
            {
                if (Math.Sqrt(n * n + x * x) % 1 == 0)
                    pointCount++;
            }

            pointCount *= 4;

            var c = pointCount > 0 ? pointCount*(pointCount - 1)*(pointCount - 2)/6 : 0;

            var s = S(n - 1);

            return c + s;

        }
    }
}
