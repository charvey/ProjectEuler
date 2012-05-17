using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem130:Problem
    {
        public override int Number
        {
            get { return 130; }
        }

        public override ValueType Solve()
        {
            throw new NotImplementedException();
            Debug.Assert(R(6) == 111111);

            for(var n=1;n<int.MaxValue;n++)
            {
                if (gcd(n, 10) == 1)
                    return null;
            }
        }

        public int A(int n)
        {
            throw new NotImplementedException();
        }

        public int R(int k)
        {
            int r = 0;

            for (var i = 0; i < k;i++)
            {
                r = r*10 + 1;
            }

            return r;
        }

        private int gcd(int a, int b)
        {
            return gcd_r(a > b ? a : b, a < b ? a : b);
        }

        private int gcd_r(int a, int b)
        {
            return b == 0 ? a : gcd_r(b, a % b);
        }
    }
}
