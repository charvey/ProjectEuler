using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem148:Problem
    {
        public override int Number
        {
            get { return 148; }
        }

        public override ValueType Solve()
        {
            const int ROWS = 1000000000;
            long[] prev = new long[] {1};
            int count = 1;

            for(int row = 2;row<=ROWS;row++)
            {
                long v = 1;
                count++;

                for(long c=1;c<row;c++)
                {
                    v = v*row/c - v;

                    if (v % 7 != 0) count++;
                    Console.WriteLine(v);
                }

                //long[] curr = new long[row];

                //curr[0] = 1;
                //curr[row - 1] = 1;

                //count += 2;

                //for (int r = 1; r < row-1;r++)
                //{
                //    curr[r] = prev[r-1] + prev[r];

                //    if (curr[r] % 7 != 0)
                //        count++;
                //    Console.WriteLine(curr[r]);
                //}

                //prev = curr;
            }

            return count;
        }
    }
}
