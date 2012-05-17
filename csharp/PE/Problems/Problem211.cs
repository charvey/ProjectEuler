using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem211:Problem
    {
        public override int Number
        {
            get { return 211; }
        }

        public override ValueType Solve()
        {
            return 1 + Enumerable.Range(2, 63999998).AsParallel().Where(n=>ips(sosod((uint)n))).Sum();
        }

        private bool ips(ulong n)
        {
            return Math.Sqrt(n)%1 == 0;
        }

        private ulong sosod(uint n)
        {
            ulong s = 0;

            for(uint f=1;f*f<=n;f++)
            {
                if(n%f==0)
                {
                    s += f*f;
                    if (f * f != n)
                        s += (n/f)*(n/f);
                }
            }

            return s;
        }
    }
}
