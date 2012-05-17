using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PE.Problems
{
    class Problem119:Problem
    {
        public override int Number
        {
            get { return 119; }
        }

        public Problem119()
        {
            //_DigitSums = Enumerable.Range(0, 10).Select(_DigitSum).ToArray();
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(2) == 512);
            Debug.Assert(S(10) == 614656);
            Debug.Assert(S(15) == 60466176);

            return S(30);
        }


        public ulong S(int n)
        {
            var dsps = new HashSet<ulong>();
            
            for(uint i=2;i<200;i++)
            {
                ulong dsp = i;
                while(dsp<ulong.MaxValue/i)
                {
                    if (DigitSum(dsp) == i && dsp >= 10)
                        dsps.Add(dsp);

                    dsp *= i;
                }
            }

            return dsps.OrderBy(i => i).ElementAt(n - 1);
        }

        private int DigitSum(ulong n)
        {
            return n == 0 ? 0 : DigitSum(n/10) + (int)(n%10);
        }
    }
}
