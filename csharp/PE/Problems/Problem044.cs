using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem044:Problem
    {
        public override int Number
        {
            get { return 044; }
        }

        public override ValueType Solve()
        {
            var pents = new List<int> {P(0)};

            for (int k = 1; k < int.MaxValue; k++)
            {
                if(pents.Count<=k)
                    pents.Add(P(k));

                for (int j = 1; j < k; j++)
                {
                    if(pents.Contains(pents[k]-pents[j]))
                    {
                        int s = pents[k] + pents[j];
                        for(int l=k+1;P(l)<=s;l++)
                        {
                            if (pents.Count <= l)
                                pents.Add(P(l));

                            if (P(l) == s)
                                return pents[k] - pents[j];
                        }
                    }
                }
            }

            throw new NotImplementedException();
        }

        public int P(int n)
        {
            return n*(3*n - 1)/2;
        }
    }
}
