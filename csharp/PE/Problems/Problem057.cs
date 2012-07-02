using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem057:Problem
    {
        public override int Number
        {
            get { return 057; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(Expansion(0).Item1 == 03 && Expansion(0).Item2 == 02);
            Debug.Assert(Expansion(1).Item1 == 07 && Expansion(1).Item2 == 05);
            Debug.Assert(Expansion(2).Item1 == 17 && Expansion(2).Item2 == 12);
            Debug.Assert(Expansion(3).Item1 == 41 && Expansion(3).Item2 == 29);

            return Enumerable.Range(0, 999).Select(Expansion).Count(e => Valid(e.Item1, e.Item2));
        }

        bool Valid(ulong n, ulong d)
        {
            while (d>0)
            {
                n /= 10;
                d /= 10;
            }

            return n > 0;
        }

        Tuple<ulong, ulong> Expansion(int x)
        {
            ulong n = 2;
            ulong d = 1;
            ulong t = 0;
            Func<int, ulong> a = i => 1U;
            Func<int, ulong> b = i => (i == 0) ? 1U : 2U;

            for (int i = x; i >= 0; i--)
            {
                t = n;
                n = b(i) * n + a(i) * d;
                d = t;
            }

            return new Tuple<ulong, ulong>(n, d);
        }
    }
}
