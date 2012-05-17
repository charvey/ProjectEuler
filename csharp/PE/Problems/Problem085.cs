using System;

namespace PE.Problems
{
    class Problem085:Problem
    {
        public override int Number
        {
            get { return 085; }
        }

        public override ValueType Solve()
        {
            const int l = 2000000;
            int smallestDiff = int.MaxValue;
            int closestArea = 0;

            for(int x=1;x<100;x++)
            {
                for(int y=1;y<=x;y++)
                {
                    int diff = Math.Abs(NumberOfRectangles(x, y)-l);

                    if(diff<smallestDiff)
                    {
                        closestArea = x*y;
                        smallestDiff = diff;
                    }
                }
            }

            return closestArea;
        }

        public int NumberOfRectangles(int h, int w)
        {
            int count = 0;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    count += (h - y)*(w - x);
                }
            }

            return count;
        }
    }
}
