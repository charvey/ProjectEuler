using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem091 : Problem
    {
        public override int Number
        {
            get { return 091; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(2) == 14);

            return S(50);
        }

        private int S(int n)
        {
            int c = 0;
            for (int x1 = 0; x1 <= n; x1++)
            {
                for (int y1 = 0; y1 <= n; y1++)
                {
                    for (int h = 1;; h++)
                    {
                        
                    }
                }
            }
            return c;
        }
    }
}
