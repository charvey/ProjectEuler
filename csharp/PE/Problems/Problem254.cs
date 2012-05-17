using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem254:Problem
    {
        public override int Number
        {
            get { return 254; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(f(342) == 32);
            Debug.Assert(sf(342) == 5);
            Debug.Assert(g(5) == 25);
            Debug.Assert(sg(5) == 7);
            Debug.Assert(Enumerable.Range(1,20).Select(sg).Sum()==156);

            return Enumerable.Range(1, 150).Select(sg).Sum();
        }

        public Problem254()
        {
            FACT = Enumerable.Range(0, 10).Select(fact).ToArray();
        }

        int fact(int n)
        {
            return n == 0 ? 1 : n*fact(n - 1);
        }

        private readonly int[] FACT;
        int f(int n)
        {
            int s = 0;

            while (n > 0)
            {
                s += FACT[n%10];
                n /= 10;
            }

            return s;
        }

        int sf(int n)
        {
            int f = this.f(n);
            int s = 0;

            while(f>0)
            {
                s += f%10;
                f /= 10;
            }

            return s;
        }

        int g(int i)
        {
            for(int n=1;n<int.MaxValue;n++)
            {
                if (sf(n) == i)
                    return n;
            }

            throw new NotImplementedException();
        }

        int sg(int i)
        {
            int g = this.g(i);
            int s = 0;

            while (g > 0)
            {
                s += g%10;
                g /= 10;
            }

            return s;
        }
    }
}
