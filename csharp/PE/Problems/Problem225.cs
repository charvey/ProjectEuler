using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem225:Problem
    {
        public override int Number
        {
            get { return 225; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(1) == 27);

            return S(124);
        }

        public int S(int n)
        {
            var T = new List<int> {0, 1, 1, 1};

            for (int i = 4; i < int.MaxValue; i++)
            {
                T.Add(T[i - 3] + T[i - 2] + T[i - 1]);
            }

            for(int odd=1;odd<int.MaxValue;odd+=2)
            {
                
            }

            return 0;

        }
    }
}
