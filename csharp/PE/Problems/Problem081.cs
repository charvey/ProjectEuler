using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PE.Problems
{
    class Problem081 : Problem
    {
        public override int Number
        {
            get { return 081; }
        }

        protected int[][] Matrix;
        protected int[][] MinSums;

        public override ValueType Solve()
        {
            const int N = 80;
            Matrix = GetFileLines("http://projecteuler.net/project/matrix.txt").Select(line => line.Split(',').Select(i => Convert.ToInt32(i)).ToArray()).ToArray();

            MinSums = new int[N][];
            for (var i = 0; i < N; i++)
                MinSums[i] = new int[N];

            MinSums[0][0] = Matrix[0][0];

            return MinSum(N - 1, N - 1);
        }

        protected int MinSum(int x, int y)
        {
            if (MinSums[x][y] != 0)
                return MinSums[x][y];

            var min = int.MaxValue;

            if (x > 0)
                min = Math.Min(min, MinSum(x - 1, y));
            if (y > 0)
                min = Math.Min(min, MinSum(x, y - 1));

            MinSums[x][y] = min + Matrix[x][y];

            return MinSums[x][y];
        }
    }
}
