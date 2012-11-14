using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

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
            //Debug.Assert(LargestGroup(56003) == 7);

            for (int i = 563; i < int.MaxValue; i++)
            {
                int digitCount = (int)Math.Ceiling(Math.Log10(i));
                for (int digits = 1; digits < Math.Pow(2, digitCount + 1) - 1; digits++)
                {
                    int baseNumber = 0;
                    int baseDigits = 0;

                    for (int digit = 0; digit < digitCount; digit++)
                    {
                        int p = (int)Math.Pow(10, digit);
                        if ((digits & (int)Math.Pow(2, digit)) != 0)
                            baseNumber += (i % (p * 10)) / p;
                        else
                            baseDigits += p;
                    }

                    int count = 0;
                    int small = 0;
                    for (int d = 0; d<= 9; d++)
                    {
                        if ((baseNumber + d * baseDigits).IsPrime())
                        {
                            if (small == 0)
                                small = (baseNumber + d * baseDigits);

                            count++;
                        }
                    }

                    if (count == 8)
                        return small;

                    if (count == 7)
                        Console.Out.WriteLine(small);
                }
            }

            


            throw new NotImplementedException();
        }

        private int LargestGroup(int n)
        {
            int max = int.MinValue;

            int p = (int)Math.Pow(2, Math.Ceiling(Math.Log10(n)))-1;
            for (int d = 1; d < p; d++)
            {
                max = Math.Max(max, SizeOfGroup(n, d));
            }

            return max;
        }

        private int SizeOfGroup(int n, int d)
        {
            int baseNumber = 0;
            int baseDigits = 0;
            int m = 0;
            int p = 1;

            while (Math.Pow(10, m) < n)
            {
                int nd = (n % (10 * p)) / p;

                if ((d & (int)Math.Pow(2, m)) == 0)
                {
                    baseNumber += nd * p;
                }
                else
                {
                    baseDigits += 1 * p;
                }

                p *= 10;
                m++;
            }

            int count = 0;
            bool first = true;
            for (int i = baseNumber; i <= baseNumber + 9 * baseDigits; i += baseDigits)
            {
                if (i >= n && i.IsPrime())
                {
                    if (first && n == i)
                        first = false;
                    else
                        return 0;
                    count++;
                }
            }

            return count;
        }
    }
}
