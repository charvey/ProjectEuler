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

            long maxX = 0;
            long maxD = 0;

            for (long d = 2; d <= 1000; d++)
            {
                if (IsPerfectSquare(d))
                {
                    continue;
                }

                long x = X(d);
                Console.WriteLine(d + " " + x);
                if(x>maxX)
                {
                    maxX = x;
                    maxD = d;
                }
            }

            return maxD;
        }

        public long X(long d)
        {
            long x = 1, y = 1;

            while (true)
            {
                long s = x * x - d * y * y;

                if (s == 1)
                    return x;
                else if (s < 1)
                    x++;
                else
                    y++;
            }
        }

        public bool IsPerfectSquare(long n)
        {
            return Math.Sqrt(n) % 1 == 0;
        }
    }
}
