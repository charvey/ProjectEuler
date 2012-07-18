using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem116:Problem
    {
        public override int Number
        {
            get { return 116; }
        }

        public override ValueType Solve()
        {
            const int L = 50;

            return S(L, 2) + S(L, 3) + S(L, 4);
        }

        private Dictionary<Tuple<int, int>, ulong> _S = new Dictionary<Tuple<int, int>, ulong>();
        private ulong S(int size, int length)
        {
            if (length > size)
                return 0;

            var key = new Tuple<int, int>(size, length);

            if (_S.ContainsKey(key))
                return _S[key];
            else
                return _S[key] = 1 + S(size - 1, length) + S(size - length, length);
        }
    }
}
