using System;
using System.Diagnostics;
using System.Linq;

namespace PE.Problems
{
    class Problem066:Problem
    {
        public override int Number
        {
            get { return 066; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(IsPerfectSquare(100));


            ulong maxX = 0;
            int maxD = 0;

            var x = Enumerable.Range(1, 1000).AsParallel().Select(d => new Tuple<int,ulong>(d,D((ulong) d))).ToList();
            
            for (int d = 0; d < 1000; d++)
            {
                if(x[d].Item2>maxX)
                {
                    maxX = x[d].Item2;
                    maxD = x[d].Item1;
                }
            }

            return maxD;
        }

        public ulong D(ulong d)
        {
            if (IsPerfectSquare(d))
                return 0;

            for (ulong x = 2; x < ulong.MaxValue; x++)
            {
                ulong x2 = x * x;

                if((x2-1)%d==0)
                {
                    ulong y2 = (x2 - 1) / d;

                    if (IsPerfectSquare(y2))
                        return x;
                }
            }

            throw new NotImplementedException();
        }

        public bool IsPerfectSquare(ulong n)
        {
            return Math.Sqrt(n) % 1 == 0;

            ulong nn = 1;

            while (nn*nn<n)
            {
                nn++;
            }

            return nn*nn == n;
        }
    }
}
