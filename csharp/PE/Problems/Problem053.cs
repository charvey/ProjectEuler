using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem053:Problem
    {
        public override int Number
        {
            get { return 053; }
        }

        public override ValueType Solve()
        {
            int count = 0;

            for(int n=1;n<=100;n++)
            {
                for(int r=1;r<=n;r++)
                {
                    ulong v = 1;
                    uint min = (uint)Math.Min(r, n - r);
                    uint max = (uint)Math.Max(r, n - r);
                    uint l = 2;
                    uint k;

                    for(k=max+1;k<=n;k++)
                    {
                        v *= k;

                        while (l <= min && v % l == 0)
                        {
                            v /= l;
                            l++;
                        }

                        if (l > min && v >= 1000000)
                        {
                            count++;
                            break;
                        }
                    }

                    if (l <= min)
                    {
                        k = 1000000;
                        for (; l <= max; l++)
                        {
                            k *= l;
                        }

                        if (v >= k)
                            count++;
                    }
                }
            }

            return count;
        }
    }
}
