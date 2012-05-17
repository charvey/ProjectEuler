using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem051:Problem
    {
        public override int Number
        {
            get { return 051; }
        }

        public override ValueType Solve()
        {
            int digits = 0;
            int order = 1;

            for (int i = 1; i < int.MaxValue; i++)
            {
                if (i == order)
                {
                    digits++;
                    order *= 10;
                }

                if (i.IsPrime())
                {
                    if (Matches(i, digits, 8))
                        return i;
                }
            }

            throw new NotImplementedException();
        }

        public bool Matches(int n, int digits, int target)
        {
            int m = (int)Math.Pow(2, digits);
            //for(int i=0)
            throw new NotImplementedException();
        }
    }
}
