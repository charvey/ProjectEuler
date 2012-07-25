using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem122:Problem
    {
        public override int Number
        {
            get { return 122; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(m(15) == 5);

            return Enumerable.Range(1, 200).Select(m).Sum();
        }

        private int m(int k)
        {
            bool[] sieve = new bool[k+1];
            sieve[1] = true;
            return m_r(k, sieve);
        }

        private int m_r(int k, bool[] sieve)
        {
            if (sieve[k])
                return 0;

            int min = int.MaxValue;

            for(int i=1;i<=k;i++)
            {
                if (!sieve[i])
                    continue;

                for (int j = i; i+j <= k; j++)
                {
                    if (!sieve[j])
                        continue;

                    if(!sieve[i+j])
                    {
                        bool[] clone = (bool[])sieve.Clone();
                        clone[i + j] = true;
                        min = Math.Min(min, m_r(k, clone));
                    }
                }
            }

            return min + 1;
        }
    }
}
