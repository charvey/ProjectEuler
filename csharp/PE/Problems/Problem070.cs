using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem070:Problem
    {
        public override int Number
        {
            get { return 070; }
        }

        private const int max = 10000000;
        int[] totients = new int[max];

        public override ValueType Solve()
        {
            PopulateTotients();

            int minN = 2;

            for (int n = 2; n < max; n++)
            {
                if (n*totients[minN] < minN*totients[n])
                    minN = n;
            }

            return minN;
        }

        private void PopulateTotients()
        {
            Branches.Add(0,new Tuple<int, int>(2, 1));
            Branches.Add(0,new Tuple<int, int>(3, 1));
            ProcessBranches();
        }

        private SortedList<int, Tuple<int, int>> Branches = new SortedList<int,Tuple<int, int>>();
        private void ProcessBranches()
        {
            while (Branches.Any())
            {
                var branch = Branches[0];

                int m = branch.Item1;
                int n = branch.Item2;

                if (m >= max)
                    return;

                totients[m]++;

                Branches.Add(max - m, new Tuple<int, int>(2*m - n, m));
                Branches.Add(max - m, new Tuple<int, int>(2*m + n, m));
                Branches.Add(max - m, new Tuple<int, int>(m + 2*n, n));
            }
        }
    }
}
