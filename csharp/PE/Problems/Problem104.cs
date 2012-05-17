using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace PE.Problems
{
    class Problem104:Problem
    {
        public override int Number
        {
            get { return 104; }
        }

        public override ValueType Solve()
        {
            BigInteger a, b, c;
            int i = 2;
            a = b = c = 1;

            while (c<123456789)
            {
                c = a + b;
                i++;
                a = b;
                b = c;
            }

            do
            {
                c = a + b;
                i++;
                a = b;
                b = c;
                
                var e = (int)(c%1000000000);
                if (IsPandigital(e))
                {
                    if (IsPandigital(Convert.ToInt32(c.ToString().Substring(0, 9))))
                        return i;
                }

            } while (true);
        }

        protected bool IsPandigital(int n)
        {
            int digits = 0;

            for (; n > 0; n /= 10)
            {
                digits |= 1 << (n - ((n/10)*10));
            }

            return digits == 1022;

        }
    }
}
