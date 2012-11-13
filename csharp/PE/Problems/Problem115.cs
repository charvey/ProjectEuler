using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PE.Problems
{
    class Problem115:Problem
    {
        public override int Number
        {
            get { return 115; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(F(03, 03) == 2);
            Debug.Assert(F(03, 07) == 17);
            Debug.Assert(F(03,29) == 673135);
            Debug.Assert(F(03,30) == 1089155);
            Debug.Assert(F(10,56) == 880711);
            Debug.Assert(F(10,57) == 1148904);

            return Enumerable.Range(0, int.MaxValue).First(n => F(50, n) > 1000000);
        }

        protected int F(int m, int n)
        {
            _fr = new int[n + 1];

            return Fr(m, n);
        }

        private int[] _fr;
        private int Fr(int m, int n)
        {
            if (n == 0)
                return 1;

            if (_fr[n] != 0)
                return _fr[n];

            int total = 0;

            for (int _m = m; _m < n; _m++)
            {
                total += Fr(m, n - _m - 1);
            }

            if (n >= m)
                total++;

            total += Fr(m, n - 1);

            _fr[n]= total;

            return _fr[n];
        }
    }
}
