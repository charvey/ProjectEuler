using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem134:Problem
    {
        public override int Number
        {
            get { return 134; }
        }

        public override ValueType Solve()
        {
            const int N = 1000000;
            const int P = 5;
            var p = Enumerable.Range(P, N-P+1).Where(n => n.IsPrime()).ToList();
            for(int i=N+1;;i++)
                if(i.IsPrime())
                {
                    p.Add(i);
                    break;
                }

            return Enumerable.Range(0, p.Count - 1).AsParallel().Select(i => S(p[i], p[i + 1])).Sum();
        }

        public long S(int p1, int p2)
        {
            long n1 = p1;
            long n2 = p2;
            long d = 1;

            while(d<n1)
                d *= 10;

            while(n1!=n2)
            {
                while (n1 < n2)
                {
                    n1 += d;
                }
                while (n1 > n2)
                {
                    n2 += p2;
                }
            }

            return n1;
        }
    }
}
