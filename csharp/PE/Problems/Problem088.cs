using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem088:Problem
    {
        public override int Number
        {
            get { return 088; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(6) == 30);

            return S(12000);
        }

        public int S(int n)
        {
            var set = new HashSet<int>();
            for(int k=2;k<=n;k++)
            {
                set.Add(mps(k));
            }

            return set.Sum();
        }

        public int mps(int k)
        {
            var c = new int[k];
            
            for(var i=0;i<k;i++)
            {
                c[i] = 1;
            }

            int e = 10;

            while(c[0]<=e)
            {
                if (c.Sum() == c.Aggregate(1, (a, g) => a * g))
                    return c.Sum();

                for(var p=k-1;k>=0;p--)
                {
                    if(c[p]<e)
                    {
                        c[p]++;
                        break;
                    }
                    else
                    {
                        c[p] = c[p-1]+1;
                    }
                }
            }

            throw new NotImplementedException();
        }
    }
}
