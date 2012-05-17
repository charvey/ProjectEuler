using System;
using System.Collections.Generic;
using System.Globalization;

namespace PE.Problems
{
    class Problem357 :Problem
    {
        public override int Number
        {
            get { return 357; }
        }

        public override ValueType Solve()
        {
            long sum = 0;
            const long max = 100000000;

            for(int i=1;i<=max;i++)
            {
                if (IsValid(i))
                    sum += i;
            }

            return sum;
        }

        private bool IsValid(int n)
        {
            var s = (int)Math.Floor(Math.Sqrt(n));

            for(uint i =1; i<=s;i++)
            {
                if(n%i==0 && !(i+n/i).IsPrime())
                    return false;
            }

            return true;
        }

    }
}
