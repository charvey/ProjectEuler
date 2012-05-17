using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem062:Problem
    {
        public override int Number
        {
            get { return 062; }
        }

        public override ValueType Solve()
        {
            var cubes = new Dictionary<ulong,List<ulong>>();

            for(ulong i=1;;i++)
            {
                ulong cube = i*i*i;
                ulong digit = cube;

                var digits = new uint[10];
                while (digit>0)
                {
                    digits[digit%10]++;
                    digit /= 10;
                }
                digit = 0;
                for(int j=0;j<digits.Length;j++)
                {
                    digit = digit*50 + digits[j];
                }

                if(!cubes.ContainsKey(digit))
                {
                    cubes[digit] = new List<ulong>();
                }

                cubes[digit].Add(cube);

                if (cubes[digit].Count == 5)
                    return cubes[digit].Min();

            }
        }
    }
}
