using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace PE.Problems
{
    class Problem097:Problem
    {
        public override int Number
        {
            get { return 097; }
        }

        public override ValueType Solve()
        {
            const ulong MOD = 10000000000;
            Debug.Assert(ModPower(2, 800, MOD) == 1163877376);

            return (ModPower(2, 7830457, MOD)*28433 + 1)%MOD;
        }

        public ulong ModPower(ulong b, ulong e, ulong mod)
        {
            ulong r = b;

            for(ulong i=1;i<e;i++)
            {
                r *= b;
                r %= mod;
            }

            return r;
        }
    }
}
