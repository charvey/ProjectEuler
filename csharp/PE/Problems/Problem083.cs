using System;
using System.Linq;

namespace PE.Problems
{
    class Problem083 : Problem
    {
        public override int Number
        {
            get { return 083; }
        }

        protected int[][] Matrix;
        protected int[][] MinSums;

        private struct Node
        {
            public int X;
            public int Y;
        }

        public override ValueType Solve()
        {
            const int N = 80;
            Matrix = GetFileLines("http://projecteuler.net/project/matrix.txt").Select(line => line.Split(',').Select(i => Convert.ToInt32(i)).ToArray()).ToArray();

            MinSums = new int[N][];
            for (var i = 0; i < N; i++)
                MinSums[i] = new int[N];

            MinSums[0][0] = Matrix[0][0];
            var nodes = new[] { new Node { X = 0, Y = 0 } }.AsEnumerable();

            throw new NotImplementedException();

            do
            {
                var node = nodes.First();

                nodes = nodes.OrderBy(n => MinSums[n.X][n.Y]);
            } while (!(nodes.First().X == N - 1 && nodes.First().Y == N - 1));

            return MinSums[N - 1][N - 1];
        }
    }
}
