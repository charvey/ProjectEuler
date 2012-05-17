using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PE.Problems
{
    class Problem082 : Problem
    {
        public override int Number
        {
            get { return 082; }
        }

        protected int[][] Matrix;
        protected int[][] Distances;

        public override ValueType Solve()
        {
            const int N = 80;
            Matrix =
                GetFileLines("http://projecteuler.net/project/matrix.txt").Select(
                    line => line.Split(',').Select(i => Convert.ToInt32(i)).ToArray()).ToArray();

            Distances = new int[N][];
            for (var i = 0; i < N; i++)
            {
                Distances[i] = new int[N];
                for (var j = 0; j < N; j++)
                    Distances[i][j] = int.MaxValue;
            }

            /*
            Distances[0][0] = Matrix[0][0];
            var q = new List<Tuple<int, int>> {new Tuple<int, int>(0, 0)};

            while (Distances[N - 1][N - 1] == int.MaxValue && q.Any())
            {
                var p = q.First();

                var min = int.MaxValue;
                Tuple<int, int> closest = new Tuple<int, int>(int.MinValue, int.MinValue);
                if (p.Item1 > 0 && Matrix[p.Item1 - 1][p.Item2] < min &&
                    Distances[p.Item1 - 1][p.Item2] == int.MaxValue)
                {
                    closest = new Tuple<int, int>(p.Item1 - 1, p.Item2);
                    min = Matrix[closest.Item1][closest.Item2];
                }
                if (p.Item1 < N - 1 && Matrix[p.Item1 + 1][p.Item2] < min &&
                    Distances[p.Item1 + 1][p.Item2] == int.MaxValue)
                {
                    closest = new Tuple<int, int>(p.Item1 + 1, p.Item2);
                    min = Matrix[closest.Item1][closest.Item2];
                }
                if (p.Item2 > 0 && Matrix[p.Item1][p.Item2 - 1] < min &&
                    Distances[p.Item1][p.Item2 - 1] == int.MaxValue)
                {
                    closest = new Tuple<int, int>(p.Item1, p.Item2 - 1);
                    min = Matrix[closest.Item1][closest.Item2];
                }
                if (p.Item2 < N - 1 && Matrix[p.Item1][p.Item2 + 1] < min &&
                    Distances[p.Item1][p.Item2 + 1] == int.MaxValue)
                {
                    closest = new Tuple<int, int>(p.Item1, p.Item2 + 1);
                    min = Matrix[closest.Item1][closest.Item2];
                }

                if (min < int.MaxValue)
                {
                    Distances[closest.Item1][closest.Item2] = Distances[p.Item1][p.Item2] + min;
                    q.Add(closest);

                    q = q.Skip(1).OrderBy(c => Distances[c.Item1][c.Item2]).ToList();
                }
            }
            */



            return Distances[N - 1][N - 1];
        }
    }
}
