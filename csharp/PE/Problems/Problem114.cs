using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PE.Problems
{
    class Problem114:Problem
    {
        public override int Number
        {
            get { return 114; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(7) == 17);
            
            return S(50);
        }

        public ulong S(int n)
        {
            return 1 + S_r(n);
        }

        private ulong[] _S_r = new ulong[51];
        public ulong S_r(int n)
        {
            if (n == 0)
                return 0;

            if (_S_r[n] != 0)
                return _S_r[n];

            ulong s = 0;

            for (int i = 3; i < n; i++)
            {
                s += S(n - i - 1);
            }

            if (n >= 3)
                s++;

            _S_r[n] = s + S_r(n - 1);

            return _S_r[n];
        }
    }
}
