using System;

namespace PE.Problems
{
    internal class Problem142 : Problem
    {
        public override int Number
        {
            get { return 142; }
        }

        public override ValueType Solve()
        {
            for (int x = 3;; x++)
            {
                for (int y = 2; y < x; y++)
                {
                    if (!ips(x - y) || !ips(x + y))
                        continue;

                    for (int z = 1; z < y; z++)
                    {
                        if (ips(x - z) && ips(x + z) && ips(y - z) && ips(y + z))
                            return x + y + x;
                    }
                }
            }
        }

        public bool ips(int n)
        {
            return Math.Sqrt(n)%1 == 0;
        }
    }
}
