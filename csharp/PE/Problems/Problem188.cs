using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem188:Problem
    {
        public override int Number
        {
            get { return 188; }
        }

        public override ValueType Solve()
        {
            const int MOD = 100000000;

            Debug.Assert(HyperMod(3, 3, MOD) == 97484987);

            return HyperMod(1777, 1855, MOD);
        }

        public ulong HyperMod(ulong a, ulong k, ulong mod)
        {
            if (k == 1)
                return a%mod;

            ulong e = HyperMod(a, k - 1, mod);

            ulong r = a;
            for (ulong i = 1; i < e; i++)
                r = (r*a)%mod;

            return r;
        }
    }
}
