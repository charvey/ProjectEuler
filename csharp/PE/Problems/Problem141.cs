using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem141:Problem
    {
        public override int Number
        {
            get { return 141; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(100000) == 124657);

            return S(1000000000000);
        }

        public ulong S(ulong n)
        {
            var poss = new List<ulong>();

            ulong s = (ulong) Math.Sqrt(n);
            for(ulong i=1;i<=s;i++)
            {
                poss.Add(i*i);
            }

            s = 0;

            foreach (var p in poss)
            {


                s += p;
            }


            return s;
        }
    }
}
