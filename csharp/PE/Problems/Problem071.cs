using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem071:Problem
    {
        private struct Fraction
        {
            public int n;
            public int d;
        }

        public override int Number
        {
            get { return 071; }
        }

        public override ValueType Solve()
        {
            const int D = 1000000;
            Fraction f = new Fraction() {n = 1, d = 3};

            for (int d = 4; d <= D; d++)
            {
                int n = 3*d/7;

                if (3 * d % 7 == 0)
                    n--;

                if(f.n*d<=n*f.d)
                {
                    f = new Fraction() {n = n, d = d};
                }
            }

            return f.n;
        }
    }
}
