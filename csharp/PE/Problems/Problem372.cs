using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem372:Problem
    {
        public override int Number
        {
            get { return 372; }
        }

        public override ValueType Solve()
        {
            const int N=2000000;
            const int M=1000000000;

            return PossiblePoints(N, M).AsParallel().Count(Qualify);
        }

        private bool Qualify(Tuple<int,int> point)
        {
            return ((point.Item2*point.Item2)/(point.Item1*point.Item1)%2 == 1);
        }

        private IEnumerable<Tuple<int,int>> PossiblePoints(int M,int N)
        {
            for(int x=M+1;x<=N;x++)
                for(int y=x;y<=N;y++)
                    yield return new Tuple<int, int>(x,y);
        }
    }
}
