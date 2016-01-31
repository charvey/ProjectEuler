using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PE.Problems
{
    class Problem297:Problem
    {
        public override int Number
        {
            get { return 297; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(1000000) == 7894453);

            throw new NotImplementedException();
            return 0;
        }

        public ulong S(ulong limit)
        {
            ulong s = 0;

            List<ulong> F = new List<ulong> { 0, 1 };
            ulong a = 0;
            ulong b = 0;



            return s;
        }
    }
}
