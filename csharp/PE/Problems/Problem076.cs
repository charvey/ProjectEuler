using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem076:Problem
    {
        public override int Number
        {
            get { return 076; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(Possbilities(5).Count == 6);

            return Possbilities(100).Count;
        }

        private HashSet<string> Possbilities(short N)
        {
            if (N == 2)
                return new HashSet<string> {"1+1"};

            var prevPossibilities = Possbilities((short)(N - 1));
            var newPossibilities = new HashSet<string>();

            foreach (var possibility in prevPossibilities)
            {
                char[] newPossibility = possibility.ToArray();
                newPossibility[0] = (char)(newPossibility[0] - 48);
                newPossibilities.Add(new string(newPossibility));

                for (var i = 2; i < possibility.Length; i+=2)
                {
                    if (possibility[i] != possibility[i - 2])
                    {
                        newPossibility = possibility.ToArray();
                        newPossibility[i] = (char)(newPossibility[i] - 48);
                        newPossibilities.Add(new string(newPossibility));
                    }
                }
            }
            newPossibilities.Add(new string(Enumerable.Range(1,N).Select(i=>'1').ToArray()));

            return newPossibilities;
        }
    }
}
