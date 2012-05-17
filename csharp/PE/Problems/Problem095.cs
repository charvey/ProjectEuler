using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem095:Problem
    {
        public override int Number
        {
            get { return 095; }
        }

        public override ValueType Solve()
        {
            throw new NotImplementedException();
            var links = new int[1000000];
            var lengths = new int[1000000];

            links[1] = 0;
            for(int i=2;i<1000000;i++)
            {
                links[i] = SumDivisors(i);
            }

            int maxLength=0;
            int minItem=int.MaxValue;

            for (int i = 2; i < 1000000; i++)
            {
                if(lengths[i]!=0)
                    continue;

                var set = new HashSet<int>{i};
                int l = 0;
                int n = i;

                do
                {
                    n = links[n];
                    
                    if(n<=1000000)
                        set.Add(n);

                    if(n==i)
                    {
                        l = set.Count;
                    }
                    else if(n>1000000 || n<=1 || lengths[n]!=0)
                    {
                        l = int.MinValue;
                    }
                } while (l==0);

                if(l>maxLength)
                    maxLength = l;

                foreach (var item in set)
                {
                    if (l >= maxLength && item < minItem)
                        minItem = item;

                    lengths[item] = l;
                }
            }

            return minItem;
        }

        int SumDivisors(int n)
        {
            int s = 1;

            for(int i=2;i*i<=n;i++)
            {
                if(n%i==0)
                {
                    s += i;
                    if (i != n / i)
                        s += n/i;
                }
            }

            return s;
        }
    }
}
