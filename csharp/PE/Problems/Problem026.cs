using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem026:Problem
    {
        public override int Number
        {
            get { return 026; }
        }

        public override ValueType Solve()
        {
            int max = int.MinValue;
            int maxD = 1;

            for(int d=2;d<1000;d++)
            {
                int c = Cycle(d);
                if (c > max)
                {
                    max = c;
                    maxD = d;
                }
            }

            return maxD;
        }

        private int Cycle(int d)
        {
            var prev = new Dictionary<int,int>();

            int r = 10;
            int p = 0;

            while (true)
            {
                if (r == 0)
                    return 0;
                if(prev.ContainsKey(r))
                    return p - prev[r];

                prev[r] = p;
                p++;
                r = (r - d*(r/d))*10;
            }
        }
    }
}
