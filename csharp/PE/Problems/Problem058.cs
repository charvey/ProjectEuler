using System;

namespace PE.Problems
{
    class Problem058:Problem
    {
        public override int Number
        {
            get { return 058; }
        }

        public override ValueType Solve()
        {
            int t = 1;
            int p = 0;
            double r;
            for (int s = 3; s < int.MaxValue; s+=2)
            {
                if ((t + 1 * (s - 1)).IsPrime())
                    p++;
                if ((t + 2 * (s - 1)).IsPrime())
                    p++;
                if ((t + 3 * (s - 1)).IsPrime())
                    p++;
                if ((t + 4 * (s - 1)).IsPrime())
                    p++;

                t += 4*s - 4;

                r = ((double)p) / (2*s-1);

                if (r < .1)
                    return s;
            }

            throw new NotImplementedException();
        }
    }
}
