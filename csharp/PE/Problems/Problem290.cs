using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem290:Problem
    {
        public override int Number
        {
            get { return 290; }
        }

        public override ValueType Solve()
        {
            ulong count = 0;
            for(ulong i=0;i<1000000000000000000;i++)
            {
                if (i.DigitSum() == (137 * i).DigitSum())
                    count++;
            }

            return count;
        }
    }
}
