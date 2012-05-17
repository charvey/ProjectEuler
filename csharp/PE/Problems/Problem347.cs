using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem347:Problem
    {
        public override int Number
        {
            get { return 347; }
        }

        public override ValueType Solve()
        {
            Debug.Assert(S(100) == 2262);

            return S(10000000);
        }

        public int S(int N)
        {
            throw new NotImplementedException();

            var primes = new List<int> {2};
            var s = (int)Math.Floor(Math.Sqrt(N));
            for(var i =3;i<s;i++)
            {
                if(i.IsPrime())
                    primes.Add(i);
            }

            for (int p = 0; p < primes.Count; p++)
            {
                for (int q = p + 1; q < primes.Count; q++)
                {

                }
            }
        }
    }
}
