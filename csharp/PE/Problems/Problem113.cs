using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem113:Problem
    {
        public override int Number
        {
            get { return 113; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(nb(6) == 12951);
            Debug.Assert(nb(10)==277032);

            return nb(100);
        }

        private ulong nb(int d)
        {
            //todo overlap
            return asc(d) + desc(d) - 10;
        }

        private ulong asc(int d)
        {
            string format = new string(Enumerable.Repeat('0',d).ToArray());
            int[] digits = new int[d];
            ulong count = 1;
            
            while (true)
            {
                int i = 0;
                for (; i < d && digits[i] == 9; i++)
                    continue;

                if (i == d)
                    break;

                digits[i]++;

                for (; i > 0; i--)
                    digits[i-1] = digits[i];

                Console.Write("A:"+((int) val(digits)).ToString(format));
                count++;
            }

            return count;
        }

        private ulong desc(int d)
        {
            string format = new string(Enumerable.Repeat('0', d).ToArray());
            int[] digits = Enumerable.Repeat(9, d).ToArray();
            ulong count = 1;

            while (true)
            {
                int i = 0;
                for (; i < d && digits[i] == 0; i++)
                    continue;

                if (i == d)
                    break;

                digits[i]--;

                for (; i > 0; i--)
                    digits[i - 1] = digits[i];

                Console.Write("D:" + ((int)val(digits)).ToString(format));
                count++;
            }

            return count;
        }

        private double val(int[] d)
        {
            return d.Select((v, i) => v * Math.Pow(10, i)).Sum();
        }
    }
}
