using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem162:Problem
    {
        public override int Number
        {
            get { return 162; }
        }

        public override ValueType Solve()
        {
            ulong s = 0;

            for(uint d=3;d<=16;d++)
            {
                ulong t=Factorial(d);

                if (d > 3)
                {
                    s += (t / 4) * 2 * Pow(d - 3);
                    s += (t / 4) * 15 * ((d > 4) ? Pow(d - 4) : 1);
                }
                else
                {
                    s += t;
                }
            }

            Debug.Assert(s == 4420408745587516162);

            return 0;
        }

        ulong[] _pow = new ulong[17];
        public ulong Pow(uint e)
        {
            if (_pow[e] != 0)
                return _pow[e];

            ulong r = 1;

            for (ulong _e = 0; _e < e; _e++)
                r *= 16;

            return _pow[e] = r;
        }

        public ulong Factorial(uint n)
        {
            return n == 1 ? 1 : n*Factorial(n - 1);
        }
    }
}
