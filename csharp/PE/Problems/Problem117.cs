using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem117:Problem
    {
        public override int Number
        {
            get { return 117; }
        }

        public override ValueType Solve()
        {
            const int L = 50;

            Debug.Assert(S(1)==1);
            Debug.Assert(S(2) == 2);
            Debug.Assert(S(3) == 4);
            Debug.Assert(S(4) == 8);
            Debug.Assert(S(5) == 15);

            return S(L);
        }

        private Dictionary<int, ulong> _S = new Dictionary<int, ulong>();
        private ulong S(int size)
        {
            if (size == 0)
                return 0;

            if (_S.ContainsKey(size))
                return _S[size];

            ulong s = 0;

            if (size == 1)
            {
                s += 1 + S(size - 1);
            }
            else if (size == 2)
            {
                s += 1 + S(size - 2);
            }
            else if (size == 3)
            {
                s += 1 + S(size - 3);
            }
            else if (size == 4)
            {
                s += 1 + S(size - 4);
            }

            if (size > 1)
            {
                s +=  S(size - 1);
            }
            if (size > 2)
            {
                s +=  S(size - 2);
            }
            if (size > 3)
            {
                s +=  S(size - 3);
            }
            if (size > 4)
            {
                s += S(size - 4);
            }

            return _S[size] = s;
        }
    }
}
