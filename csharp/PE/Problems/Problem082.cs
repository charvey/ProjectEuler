using System;
using System.Linq;

namespace PE.Problems
{
    class Problem082 : Problem
    {
        public override int Number
        {
            get { return 082; }
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

            for (int i = 0; i < N; i++)
                MinSums[i][0] = Matrix[i][0];

            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MinSums[j][i] = Matrix[j][i] + MinSums[j][i - 1];
                }

                bool changed;
                do
                {
                    changed = false;

                    for (int j = 1; j < N; j++)
                    {
                        if (MinSums[j - 1][i] + Matrix[j][i] < MinSums[j][i])
                        {
                            MinSums[j][i] = MinSums[j - 1][i] + Matrix[j][i];
                            changed = true;
                        }

                        if (MinSums[j][i] + Matrix[j - 1][i] < MinSums[j - 1][i])
                        {
                            MinSums[j - 1][i] = MinSums[j][i] + Matrix[j - 1][i];
                            changed = true;
                        }
                    }
                } while (changed);
            }

            return Enumerable.Range(0, N).Min(i => MinSums[i][N - 1]);
        }
    }
}
