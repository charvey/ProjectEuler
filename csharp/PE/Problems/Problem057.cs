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
            Debug.Assert(Expansion(1).Item1 == 03 && Expansion(1).Item2 == 02);
            Debug.Assert(Expansion(2).Item1 == 07 && Expansion(2).Item2 == 05);
            Debug.Assert(Expansion(3).Item1 == 17 && Expansion(3).Item2 == 12);
            Debug.Assert(Expansion(4).Item1 == 41 && Expansion(4).Item2 == 29);

            return Enumerable.Range(1, 1000).Select(Expansion).Count(e => Valid(e.Item1, e.Item2));
        }

        bool Valid(int n, int d)
        {
            while (d>0)
            {
                n /= 10;
                d /= 10;
            }

            return n > 0;
        }

        Tuple<int,int> Expansion(int x)
        {
            int n = 1;
            int d = 2;

            for (int i = 1; i < x; i++)
            {
                n = 2*d + 1;
                d = 2*d + 1;
            }

            n = d + 1;

            return new Tuple<int, int>(n, d);
        }
    }
}
