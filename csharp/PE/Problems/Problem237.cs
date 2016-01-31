using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem237:Problem
    {
        public override int Number
        {
            get { return 237; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(T(10) == 2329);

            return T(1000000000000) % 100000000;
        }

        public int T(int n)
        {
            throw new NotImplementedException();
        }
    }
}
