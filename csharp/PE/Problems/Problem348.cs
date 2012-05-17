using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem348:Problem
    {
        public override int Number
        {
            get { return 348; }
        }

        public Dictionary<long, int> Counts = new Dictionary<long, int>();
        public override ValueType Solve()
        {
            foreach (var p in Palindromes().AsParallel())
            {
                Counts[p] = 0;
            }

            for (long i = 1; i < short.MaxValue;i++)
            {
                long i3 = i*i*i;
                for (long j = 1; j < short.MaxValue;j++)
                {
                    long j2 = j*j;

                    long v = i3 + j2;

                    if (Counts.ContainsKey(v))
                        Counts[v]++;
                }
            }

                var r= Counts.Where(kvp=>kvp.Value==4).Select(kvp=>kvp.Key).OrderBy(v=>v);
            return r.Take(5).Sum();
        }

        public IEnumerable<long> Palindromes()
        {
            for (long i = 1; i <= 9; i++)
                yield return i;

            for (int i = 1; i < 2*(int)short.MaxValue;i++)
            {
                if(i%10==0)
                    continue;

                int m = 1;
                int r = 0;
                int n = i;

                while (n > 0)
                {
                    m *= 10;
                    r = n % 10 + r * 10;
                    n /= 10;
                }

                yield return m * r + i;
                for (var j = 0; j <= 9; j++)
                    yield return 10*m*r + j*m + i;
            }
        }

        public long MakePalindrome(int n)
        {
            int m = 1;
            int r = 0;
            int o = n;

            while(n>0)
            {
                m *= 10;
                r = n%10+r*10;
                n /= 10;
            }

            return m*r + o;
        }

        public string Reverse(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
